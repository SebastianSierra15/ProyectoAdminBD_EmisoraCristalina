using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Data;
using ProyectoAdmin_EmisoraCristalina.Models;
using System.Data;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
    public class AnuncianteController : Controller
    {
        Procedimientos cn = new Procedimientos();

        public IActionResult Index()
        {
            List<AnuncianteModel> anunciante = cn.RecopilarAnunciantes();
            ViewBag.anunciantes = anunciante;

            List<TipoDocumentoModel> tipoDocumento = cn.RecopilarTipoDocumentos();
            ViewBag.tipoDocumentos = tipoDocumento;

            List<GeneroModel> genero = cn.RecopilarGeneros();
            ViewBag.generos = genero;

            return View();
        }

        public ActionResult Buscar(string nit)
        {
            AnuncianteModel anunciante = cn.BuscarAnunciante(nit);

            return Json(anunciante);
        }

        [HttpPost]
        public ActionResult Editar(string nit, string nombre, string direccion, string telefono, string nombre1, string nombre2, string apellido1, string apellido2, string correo)
        {
            cn.EditarAnunciante(nit, nombre, direccion, telefono, nombre1, nombre2, apellido1, apellido2, correo);

            return RedirectToAction("Index", "Anunciante");
        }

        [HttpPost]
        public ActionResult Agregar(string nit, string nombre, string direccion, string telefono, string tipoDocumento, string documento, string nombre1, string nombre2, string apellido1, string apellido2, string fecha, string correo, string genero)
        {
            cn.AgregarAnunciante(nit, nombre, direccion.ToUpper(), telefono, tipoDocumento, documento, nombre1.ToUpper(), (nombre2 != null ? nombre2.ToUpper() : null), apellido1.ToUpper(), (apellido2 != null ? apellido2.ToUpper() : null), fecha, correo, genero);

            return RedirectToAction("Index", "Anunciante");
        }

    }
}
