using System;
using System.Collections.Generic;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using AlocaGFT.Utils;
using AlocaGFT.Utils.Exceptions;
using AlocaGFT.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlocaGFT.Controllers
{
    [Authorize(Policy = "Admin")]
    public class CargosController : Controller
    {
        private readonly ICargoRepository _repository;
        public CargosController(ICargoRepository repository)
        {
            this._repository = repository;
        }

        public IActionResult Index()
        {
            List<Cargo> cargos = _repository.GetTodosAtivos();
            return View(cargos);
        }

        public IActionResult Cadastrar()
        {
            return RedirectToAction("Cargo");
        }

        [HttpGet("wa/[controller]/{id}")]
        public IActionResult Cargo(long id = 0)
        {
            try
            {
                if (id > 0)
                {
                    Cargo cargo = _repository.GetPorId(id);
                    return View(cargo.ToViewModel());
                }
                return View();
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Cargo não encontrado!");
            }
        }

        [HttpPost]
        public IActionResult Salvar(CargoViewModel cargoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (cargoVM == null) throw new Exception("Cargo inválido!");

                    _repository.Salvar(cargoVM.ToModel());

                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Cargo", cargoVM);
                }
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Cargo não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("wa/[controller]/deletar/{id}")]
        public IActionResult Deletar(long id)
        {
            try
            {
                if (id > 0)
                {
                    _repository.DesativarPorId(id);
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