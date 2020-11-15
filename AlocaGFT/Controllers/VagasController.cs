using System;
using System.Collections.Generic;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using AlocaGFT.Utils;
using AlocaGFT.Utils.Exceptions;
using AlocaGFT.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AlocaGFT.Controllers
{
    [Authorize(Policy = "User")]
    public class VagasController : Controller
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly ITecnologiaRepository _tecnologiaRepository;
        private readonly IAlocacaoRepository _alocacaoRepository;
        public VagasController(
        IVagaRepository vagaRepository,
        ITecnologiaRepository tecnologiaRepository,
        IAlocacaoRepository alocacaoRepository)
        {
            this._vagaRepository = vagaRepository;
            this._tecnologiaRepository = tecnologiaRepository;
            this._alocacaoRepository = alocacaoRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<VagaViewModel> vagasVM = _vagaRepository.GetTodosAtivosApenasComVagas().ToViewModel(_tecnologiaRepository);
            return View(vagasVM);
        }

        public IActionResult Cadastrar()
        {
            return RedirectToAction("Vaga");
        }

        [HttpGet("wa/[controller]/{id}")]
        public IActionResult Vaga(long id = 0)
        {
            try
            {
                ViewData["tecnologias"] = _tecnologiaRepository.GetTodosAtivos();

                if (id > 0)
                {
                    Vaga vaga = _vagaRepository.GetPorId(id);
                    List<Tecnologia> tecnologias = _tecnologiaRepository.GetTecnologiasPorVaga(vaga);

                    var vagaVM = vaga.ToViewModel(tecnologias);
                    var funcionariosAlocados = _alocacaoRepository.GetFuncionariosNaVaga(vaga);
                    vagaVM.FuncionariosAlocados = funcionariosAlocados;

                    return View(vagaVM);
                }
                return View();
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Vaga não encontrada!");
            }
        }

        [HttpPost]
        public IActionResult Salvar(VagaViewModel vagaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (vagaVM == null) throw new Exception("Vaga inválida!");
                    var vaga = vagaVM.ToModel();

                    _vagaRepository.Salvar(vaga);
                    _tecnologiaRepository.SalvarTecnologiasDaVaga(vaga, vagaVM.TecnologiaIds);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["tecnologias"] = _tecnologiaRepository.GetTodosAtivos();

                    return View("Vaga", vagaVM);
                }
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Vaga não encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("wa/[controller]/deletar/{id}")]
        public IActionResult Deletar(long id)
        {
            try
            {
                if (id > 0)
                {
                    _vagaRepository.DesativarPorId(id);
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("wa/[controller]/{id}/Detalhes")]
        public IActionResult DetalhesJSON(long id)
        {
            try
            {
                if (id > 0)
                {
                    Vaga vaga = _vagaRepository.GetPorId(id);
                    var tecnologias = _tecnologiaRepository.GetTecnologiasPorVaga(vaga);

                    return Json(vaga.ToViewModel(tecnologias));
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}