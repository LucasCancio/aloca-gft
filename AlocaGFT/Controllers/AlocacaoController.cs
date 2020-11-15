using System;
using System.Collections.Generic;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using AlocaGFT.Utils;
using AlocaGFT.Utils.Enums;
using AlocaGFT.ViewModels;
using AlocaGFT.ViewModels.Alocacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace AlocaGFT.Controllers
{
    [Authorize(Policy = "User")]
    public class AlocacaoController : Controller
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ITecnologiaRepository _tecnologiaRepository;
        private readonly IAlocacaoRepository _alocacaoRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AlocacaoController(IVagaRepository vagaRepository,
        IFuncionarioRepository funcionarioRepository,
        ITecnologiaRepository tecnologiaRepository,
        IAlocacaoRepository alocacaoRepository,
        UserManager<IdentityUser> userManager
        )
        {
            this._vagaRepository = vagaRepository;
            this._funcionarioRepository = funcionarioRepository;
            this._tecnologiaRepository = tecnologiaRepository;
            this._alocacaoRepository = alocacaoRepository;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("wa/[controller]")]
        [HttpGet("wa/alocar")]
        [HttpGet("wa/historico")]
        public IActionResult Index()
        {
            var alocacoes = _alocacaoRepository.GetTodosAtivos();
            alocacoes.ForEach(alocacao =>
            {
                alocacao.username = _userManager.GetUserName(User);
            });

            var viewModel = new AlocacaoViewModel()
            {
                Vagas = _vagaRepository.GetTodosAtivosApenasComVagas().ToViewModel(_tecnologiaRepository),
                Alocacoes = alocacoes
            };

            return View(viewModel);
        }

        [HttpGet("wa/[controller]/Vaga")]
        public IActionResult Vaga(long VagaId)
        {
            var funcionariosEmWa = _funcionarioRepository.GetTodosAtivosEmWA();
            var vaga = _vagaRepository.GetPorId(VagaId);
            var tecnologiasDaVaga = _tecnologiaRepository.GetTecnologiasPorVaga(vaga);
            var funcionariosAlocados = _alocacaoRepository.GetFuncionariosNaVaga(vaga);


            var viewModel = new VagaAlocacaoViewModel()
            {
                FuncionariosEmWA = funcionariosEmWa.ToViewModel(_tecnologiaRepository),
                Vaga = vaga.ToViewModel(tecnologiasDaVaga),
                FuncionariosAlocados = funcionariosAlocados.ToViewModel(_tecnologiaRepository)
            };


            return View("vaga-alocacao", viewModel);
        }



        [HttpPost("wa/[controller]/Funcionarios")]
        public IActionResult Funcionarios([FromBody] List<long> funcionariosIds)
        {
            try
            {
                List<Funcionario> funcionarios = new List<Funcionario>();

                foreach (long id in funcionariosIds)
                {
                    Funcionario funcionario = _funcionarioRepository.GetPorId(id);
                    funcionarios.Add(funcionario);
                }

                return Json(funcionarios.ToViewModel(_tecnologiaRepository));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("wa/[controller]/AlocarEmVaga")]
        public IActionResult AlocarEmVaga(VagaAlocacaoViewModel alocaVM)
        {
            try
            {
                if (!alocaVM.Vaga.Id.HasValue)
                {
                    return Vaga(0);
                }

                Vaga vaga = _vagaRepository.GetPorId(alocaVM.Vaga.Id.Value);

                List<Funcionario> funcionariosAlocadosModels = new List<Funcionario>();
                alocaVM.FuncionariosAlocados.ForEach(funcVm =>
                {
                    var funcionario = _funcionarioRepository.GetPorId(funcVm.Id.Value);
                    funcionariosAlocadosModels.Add(funcionario);
                });


                int qtdFuncionariosParaAlocar = funcionariosAlocadosModels.Where(func => func.NaoEstaAlocado(vaga)).Count();

                List<long> funcionariosIdsParaAlocar = funcionariosAlocadosModels.Select(func => func.id).ToList();
                List<Funcionario> funcionariosAlocadosDoBanco = _alocacaoRepository.GetFuncionariosNaVaga(vaga);
                List<long> funcionariosIdsAlocadosParaDesalocar = funcionariosAlocadosDoBanco
                                                                            .Select(func => func.id)
                                                                            .Where(id => !funcionariosIdsParaAlocar.Contains(id))
                                                                            .ToList();


                bool limiteDeVagasExcedido= qtdFuncionariosParaAlocar > alocaVM.Vaga.QtdVaga;
                if (limiteDeVagasExcedido)
                {
                    var errors = new Dictionary<string, string>(){
                        {"Vaga.QtdVaga",$"Limite de vagas excedido! A vaga possui apenas {alocaVM.Vaga.QtdVaga} posição(oes)."}
                    };
                    
                    return View("vaga-alocacao", GerarViewModelComErros(vaga, errors, funcionariosAlocadosDoBanco));
                }

                bool ninguemParaDesalocarEAlocar = funcionariosIdsAlocadosParaDesalocar.Count == 0 && funcionariosIdsParaAlocar.Count == 0;
                if (ninguemParaDesalocarEAlocar)
                {
                    var errors = new Dictionary<string, string>(){
                        {"Vaga.QtdVaga","É Preciso selecionar pelo menos um funcionário."}
                    };
                    return View("vaga-alocacao", GerarViewModelComErros(vaga, errors, funcionariosAlocadosDoBanco));
                }


                foreach (Funcionario funcionario in funcionariosAlocadosModels)
                {
                    if (funcionario.NaoEstaAlocado(vaga))
                    {
                        AlocarFuncionarioEmVaga(funcionario, vaga);
                    }
                }

                DesalocarFuncionariosPorId(funcionariosIdsAlocadosParaDesalocar, vaga);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        public VagaAlocacaoViewModel GerarViewModelComErros(Vaga vaga, Dictionary<string, string> errors, List<Funcionario> funcionariosAlocadosDoBanco = null)
        {
            if (funcionariosAlocadosDoBanco == null) funcionariosAlocadosDoBanco = _alocacaoRepository.GetFuncionariosNaVaga(vaga);

            var funcionariosEmWa = _funcionarioRepository.GetTodosAtivosEmWA();
            var tecnologiasDaVaga = _tecnologiaRepository.GetTecnologiasPorVaga(vaga);

            var viewModel = new VagaAlocacaoViewModel() //Deve retornar todas as informações (Tecnologia, Vaga e funcionarios em wa) para a View
            {
                FuncionariosEmWA = funcionariosEmWa.ToViewModel(_tecnologiaRepository),
                Vaga = vaga.ToViewModel(tecnologiasDaVaga),
                FuncionariosAlocados = funcionariosAlocadosDoBanco.ToViewModel(_tecnologiaRepository)
            };

            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }   

            return viewModel;
        }
        private void AlocarFuncionarioEmVaga(Funcionario funcionario, Vaga vaga)
        {
            var alocacao = new Alocacao()
            {
                applicationUserId = _userManager.GetUserId(User),
                vaga = vaga,
                funcionario = funcionario,
                data_operacao = DateTime.Now,
            };

            _funcionarioRepository.AlocarEmVaga(vaga, funcionario);
            alocacao.operacao = OperacoesAlocacao.ALOCAR;
            _alocacaoRepository.Salvar(alocacao);
        }
        private void DesalocarFuncionariosPorId(List<long> funcionariosIds, Vaga vaga)
        {
            foreach (long funcionarioId in funcionariosIds)
            {
                Funcionario funcionario = _funcionarioRepository.GetPorId(funcionarioId);

                var alocacao = new Alocacao()
                {
                    applicationUserId = _userManager.GetUserId(User),
                    vaga = vaga,
                    funcionario = funcionario,
                    data_operacao = DateTime.Now,
                };

                _funcionarioRepository.DesalocarEmVaga(vaga, funcionario);
                alocacao.operacao = OperacoesAlocacao.DESALOCAR;
                _alocacaoRepository.Salvar(alocacao);
            }
        }
    }
}