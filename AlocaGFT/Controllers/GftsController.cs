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
    [Authorize(Policy = "User")]
    public class GftsController : Controller
    {
        private readonly IGftRepository _gftRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        public GftsController(IGftRepository gftRepository, IEnderecoRepository enderecoRepository)
        {
            this._gftRepository = gftRepository;
            this._enderecoRepository = enderecoRepository;
        }

        public IActionResult Index()
        {
            List<Gft> gfts = _gftRepository.GetTodosAtivos();
            return View(gfts);
        }

        public IActionResult Cadastrar()
        {
            return RedirectToAction("Gft");
        }

        [HttpGet("wa/[controller]/{id}")]
        public IActionResult Gft(long id = 0)
        {
            try
            {
                if (id > 0)
                {
                    Gft gft = _gftRepository.GetPorId(id);
                    return View(gft.ToViewModel());
                }
                return View();
            }
            catch (EntidadeNaoEncontradaException)
            {
                return NotFound("Gft não encontrada!");
            }
        }

        [HttpPost]
        public IActionResult Salvar(GftViewModel gftVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (gftVM == null) throw new Exception("Gft inválida!");

                    _enderecoRepository.Salvar(gftVM.Endereco);
                    _gftRepository.Salvar(gftVM.ToModel());

                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Gft", gftVM);
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
                    _gftRepository.DesativarPorId(id);
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