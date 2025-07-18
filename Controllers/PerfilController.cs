using Microsoft.AspNetCore.Mvc;
using RadioDemo.Data;
using RadioDemo.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RadioDemo.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        Procedimientos cn = new Procedimientos();

        public IActionResult Index()
        {
            var user = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            VendedorModel vendedor = cn.BuscarVendedor(user + "");

            return View(vendedor);
        }

        [HttpPost]
        [Authorize(Roles = "Editar Perfil")]
        public ActionResult Editar(string id, string username, string nombre1, string nombre2, string apellido1, string apellido2, string correo, string contrasenia)
        {
            cn.EditarPerfil(id, username, nombre1.ToUpper(), (nombre2 != null ? nombre2.ToUpper() : null), apellido1.ToUpper(), (apellido2 != null ? apellido2.ToUpper() : null), correo, contrasenia);

            return RedirectToAction("Index", "Home");
        }

    }
}
