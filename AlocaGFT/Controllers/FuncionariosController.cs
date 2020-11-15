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
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IGftRepository _gftRepository;
        private readonly ITecnologiaRepository _tecnologiaRepository;
        public FuncionariosController(
            IFuncionarioRepository funcionarioRepository,
            ICargoRepository cargoRepository,
            IGftRepository gftRepository,
            ITecnologiaRepository tecnologiaRepository
            )
        {
            this._funcionarioRepository = funcionarioRepository;
            this._cargoRepository = cargoRepository;
            this._gftRepository = gftRepository;
            this._tecnologiaRepository = tecnologiaRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<FuncionarioViewModel> funcionariosVM = _funcionarioRepository
                                                                    .GetTodosAtivosEmWA()
                                                                    .ToViewModel(_tecnologiaRepository);
            return View(funcionariosVM);
        }

        public IActionResult Cadastrar()
        {
            return RedirectToAction("Funcionario");
        }

        [HttpGet("wa/[controller]/{id}")]
        public IActionResult Funcionario(long id = 0)
        {
            try
            {
                ViewData["cargos"] = _cargoRepository.GetTodosAtivos();
                ViewData["gfts"] = _gftRepository.GetTodosAtivos();
                ViewData["tecnologias"] = _tecnologiaRepository.GetTodosAtivos();

                if (id > 0)
                {
                    Funcionario funcionario = _funcionarioRepository.GetPorId(id);
                    List<Tecnologia> tecnologias = _tecnologiaRepository.GetTecnologiasPorFuncionario(funcionario);
                    return View(funcionario.ToViewModel(tecnologias));
                }

                return View();
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Funcionário não encontrado!");
            }
        }

        [HttpPost]
        public IActionResult Salvar(FuncionarioViewModel funcionarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (funcionarioVM == null) throw new Exception("Funcionário inválido!");
                    Funcionario funcionario = funcionarioVM.ToModel();
                    funcionario.cargo = _cargoRepository.GetPorId(funcionarioVM.CargoId.Value);
                    funcionario.gft = _gftRepository.GetPorId(funcionarioVM.GftId.Value);

                    _funcionarioRepository.Salvar(funcionario);
                    _tecnologiaRepository.SalvarTecnologiasDoFuncionario(funcionario, funcionarioVM.TecnologiaIds);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["cargos"] = _cargoRepository.GetTodosAtivos();
                    ViewData["gfts"] = _gftRepository.GetTodosAtivos();
                    ViewData["tecnologias"] = _tecnologiaRepository.GetTodosAtivos();

                    return View("Funcionario", funcionarioVM);
                }
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Funcionario não encontrado");
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
                    _funcionarioRepository.DesativarPorId(id);
                    return RedirectToAction("Index");
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