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
        public ActionResult EditarPerfil(string id, string username, string nombre1, string nombre2, string apellido1, string apellido2, string correo)
        {
            try
            {
                cn.EditarPerfil(id, username, nombre1, (nombre2 != null ? nombre2 : null), apellido1, (apellido2 != null ? apellido2 : null), correo);
                TempData["Mensaje"] = "Perfil actualizado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al actualizar el perfil: " + ex.Message;
            }

            return RedirectToAction("Index", "Perfil");
        }

        [HttpPost]
        [Authorize(Roles = "Editar Perfil")]
        public IActionResult CambiarContrasenia(string id, string contraseniaActual, string nuevaContrasenia, string confirmarContrasenia)
        {
            try
            {
                if (nuevaContrasenia != confirmarContrasenia)
                {
                    TempData["Error"] = "Las nuevas contraseñas no coinciden.";
                    return RedirectToAction("Index");
                }

                if (!cn.ValidarContrasenia(id, contraseniaActual))
                {
                    TempData["Error"] = "La contraseña actual es incorrecta.";
                    return RedirectToAction("Index");
                }

                cn.ActualizarContrasenia(id, nuevaContrasenia);
                TempData["Mensaje"] = "Contraseña actualizada correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al actualizar la contraseña: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

    }
}
