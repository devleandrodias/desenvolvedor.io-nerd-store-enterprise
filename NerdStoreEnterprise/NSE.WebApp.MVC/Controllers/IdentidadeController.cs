﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpGet, Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost, Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            UsuarioRespostaLogin resposta = await _autenticacaoService.Registro(usuarioRegistro);

            if (false) return View(usuarioRegistro);

            // Realizar login na App

            return RedirectToAction("Index", "Home");
        }

        [HttpGet, Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            UsuarioRespostaLogin resposta = await _autenticacaoService.Login(usuarioLogin);

            if (false) return View(usuarioLogin);

            // Realizar login na App

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
