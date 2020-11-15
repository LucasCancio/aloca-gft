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
    public class TecnologiasController : Controller
    {
        private readonly ITecnologiaRepository _repository;
        public TecnologiasController(ITecnologiaRepository repository)
        {
            this._repository = repository;
        }

        public IActionResult Index()
        {
            List<Tecnologia> tecnologias = _repository.GetTodosAtivos();
            return View(tecnologias);
        }
        public IActionResult Cadastrar()
        {
            return RedirectToAction("Tecnologia");
        }

        [HttpGet("wa/[controller]/{id}")]
        public IActionResult Tecnologia(long id = 0)
        {
            try
            {
                if (id > 0)
                {
                    Tecnologia tecnologia = _repository.GetPorId(id);
                    return View(tecnologia.ToViewModel());
                }
                return View();
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Tecnologia não encontrado!");
            }
        }

        [HttpPost]
        public IActionResult Salvar(TecnologiaViewModel tecnologiaVM)
        {
            try
            {
                tecnologiaVM.ImageSource = tecnologiaVM.Image == null ? tecnologiaVM.ImageName : tecnologiaVM.Image.FileName;
                if (string.IsNullOrEmpty(tecnologiaVM.ImageSource))
                {
                    ModelState.AddModelError("Image", "Escolha uma imagem para a tecnologia.");
                }
                var imageNameAtual = tecnologiaVM.ImageName;

                if (ModelState.IsValid)
                {
                    if (tecnologiaVM == null) throw new Exception("Tecnologia inválida!");
                    var tecnologia = tecnologiaVM.ToModel();
                    _repository.Salvar(tecnologia);

                    if (tecnologiaVM.ImageSource != imageNameAtual) _repository.UploadTecnologia(tecnologiaVM.Image, tecnologia);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Tecnologia", tecnologiaVM);
                }
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Tecnologia não encontrada");
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