﻿using Microsoft.AspNetCore.Mvc;
using RadioDemo.Data;
using RadioDemo.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RadioDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        Procedimientos cn = new Procedimientos();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Validar(string username, string contrasenia)
        {
            VendedorModel vendedor = cn.ValidarVendedor(username, contrasenia);

            if (vendedor.Username != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, vendedor.Id.ToString()),
                    new Claim(ClaimTypes.Name, vendedor.Username),
                    new Claim(ClaimTypes.Actor, vendedor.Rol.Id + "")
                };

                foreach (PermisoModel permiso in vendedor.Rol.Permisos)
                {
                    claims.Add(new Claim(ClaimTypes.Role, permiso.Nombre));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            TempData["Mensaje"] = "Usuario o contraseña incorrectos.";
            return RedirectToAction("Index", "Login");
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
