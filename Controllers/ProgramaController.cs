using Microsoft.AspNetCore.Mvc;
using RadioDemo.Data;
using RadioDemo.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace RadioDemo.Controllers
{
    [Authorize(Roles = "Consultar Programa")]
    public class ProgramaController : Controller
    {
        Procedimientos cn = new Procedimientos();

        public IActionResult Index()
        {
            List<ProgramaModel> programa = cn.RecopilarProgramas();
            ViewBag.programas = programa;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Editar Programa")]
        public ActionResult Editar(string id, string nombre, string estado)
        {
            cn.EditarPrograma(id, nombre, estado);

            return RedirectToAction("Index", "Programa");
        }

        [HttpPost]
        [Authorize(Roles = "Agregar Programa")]
        public ActionResult Agregar(string nombre)
        {
            cn.AgregarPrograma(nombre);

            return RedirectToAction("Index", "Programa");
        }
    }
}
