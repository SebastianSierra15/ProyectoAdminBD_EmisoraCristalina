using Microsoft.AspNetCore.Mvc;
using RadioDemo.Data;
using RadioDemo.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace RadioDemo.Controllers
{
    [Authorize(Roles = "Consultar Tarifa")]
    public class TarifaController : Controller
    {
        Procedimientos cn = new Procedimientos();

        public IActionResult Index()
        {
            List<TarifaModel> tarifa = cn.RecopilarTarifas();
            ViewBag.tarifas = tarifa;

            List<ProgramaModel> programa = cn.RecopilarProgramas();
            ViewBag.programas = programa;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Editar Tarifa")]
        public ActionResult Editar(string id, string programa, string rangoInicial, string rangoFinal, string valorPublicado, string valorEspecial)
        {
            cn.EditarTarifa(id, programa, rangoInicial, rangoFinal, valorPublicado, valorEspecial);

            return RedirectToAction("Index", "Tarifa");
        }

        [HttpPost]
        [Authorize(Roles = "Agregar Tarifa")]
        public ActionResult Agregar(string rangoInicial, string rangoFinal, string valorPublicado, string valorEspecial, string programa)
        {
            cn.AgregarTarifa(rangoInicial, rangoFinal, valorPublicado, valorEspecial, programa);

            return RedirectToAction("Index", "Tarifa");
        }

        [HttpPost]
        [Authorize(Roles = "Eliminar Tarifa")]
        public ActionResult Eliminar(string id)
        {
            cn.EliminarTarifa(id);

            return RedirectToAction("Index", "Tarifa");
        }
    }
}
