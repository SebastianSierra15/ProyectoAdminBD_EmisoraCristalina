using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Data;
using ProyectoAdmin_EmisoraCristalina.Models;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
    public class PerfilController : Controller
    {
        Procedimientos cn = new Procedimientos();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(string id, string username, string estado, string rol, string nombre1, string nombre2, string apellido1, string apellido2, string correo)
        {
            cn.EditarVendedor(id, username, estado, rol, nombre1.ToUpper(), (nombre2 != null ? nombre2.ToUpper() : null), apellido1.ToUpper(), (apellido2 != null ? apellido2.ToUpper() : null), correo);

            return RedirectToAction("Index", "Home");
        }

    }
}
