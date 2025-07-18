using Microsoft.AspNetCore.Mvc;
using RadioDemo.Data;
using Microsoft.AspNetCore.Authorization;
using RadioDemo.Models;
using System.Diagnostics;

namespace RadioDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Procedimientos cn = new Procedimientos();

        public IActionResult Index()
        {
            ViewBag.ContratosActivos = cn.ContarContratosActivos();
            ViewBag.TotalAnunciantes = cn.ContarAnunciantes();
            ViewBag.TotalVendedores = cn.ContarVendedores();

            return View();
        }

    }
}
