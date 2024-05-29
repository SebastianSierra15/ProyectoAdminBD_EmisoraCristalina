using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Models;
using System.Diagnostics;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            
            return View();
        }

    }
}
