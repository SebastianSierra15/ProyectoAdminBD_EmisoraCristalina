using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Data;
using ProyectoAdmin_EmisoraCristalina.Models;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
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
        public ActionResult Editar(string id, string nombre, string estado)
        {
            cn.EditarPrograma(id, nombre, estado);

            return RedirectToAction("Index", "Programa");
        }

        [HttpPost]
        public ActionResult Agregar(string nombre)
        {
            cn.AgregarPrograma(nombre);

            return RedirectToAction("Index", "Programa");
        }
    }
}
