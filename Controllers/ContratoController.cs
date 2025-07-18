using Microsoft.AspNetCore.Mvc;
using RadioDemo.Data;
using RadioDemo.Models;
using System.Security.Claims;
using DinkToPdf;
using Microsoft.AspNetCore.Http.Extensions;
using DinkToPdf.Contracts;
using WebReservas.Data;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;

namespace RadioDemo.Controllers
{
    [Authorize(Roles = "Consultar Contrato")]
    public class ContratoController : Controller
    {
        Procedimientos cn = new Procedimientos();
        ConexionMongo mongo = new ConexionMongo();

        private readonly IConverter _converter;

        public ContratoController(IConverter converter)
        {
            _converter = converter;
        }

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

        [Authorize(Roles = "Crear Contrato")]
        public IActionResult CrearContrato()
        {
            List<AnuncianteModel> anunciante = cn.RecopilarAnunciantes();
            ViewBag.anunciantes = anunciante;

            List<TarifaModel> tarifa = cn.RecopilarTarifas();
            ViewBag.tarifas = tarifa;

            return View();
        }

        public IActionResult VistaPDF(string id)
        {
            string[] aux = id.Split(',');

            ContratoModel contrato = cn.BuscarContrato(aux[0]);
            ViewBag.num = aux[1];

            return View(contrato);
        }

        [Authorize(Roles = "Crear Contrato")]
        public IActionResult Crear(IFormCollection form)
        {
            var nombre = form["nombre"];
            var valor = form["valor"];
            var fechaInicio = DateTime.TryParse(form["fechaInicio"], out var fi) ? fi : DateTime.MinValue;
            var fechaFin = DateTime.TryParse(form["fechaFin"], out var ff) ? ff : DateTime.MinValue;
            var anunciante = form["anunciante"];
            var cuniasNombre = form["cunia[][nombre]"];
            var cuniasDescripcion = form["cunia[][descripcion]"];
            var cuniasTarifa = form["cunia[][tarifa]"];

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(anunciante))
            {
                TempData["Error"] = "Nombre del contrato y anunciante son obligatorios.";
                return RedirectToAction("CrearContrato");
            }

            if (!int.TryParse(valor, out int valorInt) || valorInt <= 0)
            {
                TempData["Error"] = "El valor del contrato debe ser un número positivo.";
                return RedirectToAction("CrearContrato");
            }

            if (fechaInicio == DateTime.MinValue || fechaFin == DateTime.MinValue)
            {
                TempData["Error"] = "Debe seleccionar fechas válidas.";
                return RedirectToAction("CrearContrato");
            }

            if (fechaInicio >= fechaFin)
            {
                TempData["Error"] = "La fecha de inicio debe ser menor a la fecha de finalización.";
                return RedirectToAction("CrearContrato");
            }

            if (fechaInicio < DateTime.Today.AddDays(1))
            {
                TempData["Error"] = "La fecha de inicio debe ser al menos desde mañana.";
                return RedirectToAction("CrearContrato");
            }

            if (cuniasNombre.Count == 0)
            {
                TempData["Error"] = "Debe agregar al menos una cuña al contrato.";
                return RedirectToAction("CrearContrato");
            }

            var user = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            int numCunias = cuniasNombre.Count;
            string id = cn.AgregarContrato(nombre, fechaInicio.ToString("yyyy-MM-dd"), fechaFin.ToString("yyyy-MM-dd"), anunciante, valor, user, numCunias);

            for (int i = 0; i < cuniasNombre.Count; i++)
            {
                cn.AgregarCunia(cuniasNombre[i] + "", cuniasDescripcion[i] + "", cuniasTarifa[i] + "", id);
            }

            string idView = (id + "," + cuniasNombre.Count);

            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Contrato/VistaPDF/{idView}";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        Page=url_pagina
                    }
                }
            };
            byte[] archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "Contrato.pdf";
            var file = File(archivoPDF, "application/pdf", nombrePDF);

            using (MemoryStream ms = new MemoryStream(archivoPDF))
            {
                ObjectId idPDF = mongo.InsertarPDF(archivoPDF, "Contrato.pdf");
                cn.GuardarPdf(id, idPDF.ToString());

                TempData["ContratoCreado"] = "Contrato creado exitosamente.";
                TempData["PdfId"] = idPDF.ToString();

                return RedirectToAction("Index");
            }
        }

        public IActionResult DescargarPDF(string id)
        {
            ObjectId idPDF = new ObjectId(id);
            byte[] contenidoPDF = mongo.ObtenerPDF(idPDF);

            return File(contenidoPDF, "application/pdf", "Contrato.pdf");
        }

        [HttpPost]
        [Authorize(Roles = "Crear Contrato")]
        public IActionResult BuscarTarifa(string id)
        {
            TarifaModel tarifa = cn.BuscarTarifa(id);

            return Json(tarifa);
        }
    }
}
