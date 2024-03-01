﻿using Microsoft.AspNetCore.Mvc;
using ProyectoASPNET.Extensions;
using ProyectoASPNET.Models;

namespace ProyectoASPNET.Controllers
{
    public class AuthController : Controller
    {
        private RepositoryRestaurantes repo;

        public AuthController(RepositoryRestaurantes repo)
        {
            this.repo = repo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            Usuario usuario = await this.repo.LoginUsuario(email, password);
            if (usuario != null)
            {
                HttpContext.Session.SetObject("USER", usuario.IdUsuario);
                HttpContext.Session.SetObject("TIPOUSER", usuario.TipoUsuario);
                return RedirectToAction("Index", "Restaurantes");
            }
            else
            {
                ViewData["MENSAJE"] = "Error";
                return View();
            }

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Usuario usuario)
        {
            await this.repo.RegisterUsuario(usuario);
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetObject("USER", 0);
            HttpContext.Session.SetObject("TIPOUSER", 0);
            return RedirectToAction("Index", "Home");
        }
    }
}
