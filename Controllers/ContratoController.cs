using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Data;
using ProyectoAdmin_EmisoraCristalina.Models;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
    public class ContratoController : Controller
    {
        Procedimientos cn = new Procedimientos();

        public IActionResult Index()
        {
            List<ContratoModel> contrato = cn.RecopilarContratos();
            ViewBag.contratos = contrato;

            List<VendedorModel> vendedor = cn.RecopilarVendedores();
            ViewBag.vendedores = vendedor;

            List<AnuncianteModel> anunciante = cn.RecopilarAnunciantes();
            ViewBag.anunciantes = anunciante;

            return View();
        }

        public IActionResult CrearContrato()
        {
            List<AnuncianteModel> anunciante = cn.RecopilarAnunciantes();
            ViewBag.anunciantes = anunciante;

            List<TarifaModel> tarifa = cn.RecopilarTarifas();
            ViewBag.tarifas = tarifa;

            return View();
        }

        [HttpPost]
        public IActionResult Crear(IFormCollection form)
        {
            var cunias = new List<List<string>>();
            var cuniasNombre = form["cunias[][nombre]"];
            var cuniasDescripcion = form["cunias[][descripcion]"];
            var cuniasTarifa = form["cunias[][tarifa]"];

            for (int i = 0; i < cuniasNombre.Count; i++)
            {
                var lista = new List<string>();
                lista.Add(cuniasNombre[i] + "");
                lista.Add(cuniasDescripcion[i] + "");
                lista.Add(cuniasTarifa[i] + "");
                cunias.Add(lista);
            }

            return RedirectToAction("Index", "Contrato");
        }

        [HttpPost]
        public IActionResult BuscarTarifa(string id)
        {
            TarifaModel tarifa = cn.BuscarTarifa(id);

            return Json(tarifa);
        }
    }
}
