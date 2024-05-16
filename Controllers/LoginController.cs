using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Data;
using ProyectoAdmin_EmisoraCristalina.Models;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
    public class LoginController : Controller
    {

        Procedimientos cn = new Procedimientos();

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Validar(string username, string contrasenia)
        {
            VendedorModel vendedor = cn.ValidarVendedor(username, contrasenia);
            
            if (vendedor.Username != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Login");
        }

    }
}
