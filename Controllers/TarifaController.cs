using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Data;
using ProyectoAdmin_EmisoraCristalina.Models;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
    public class TarifaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
