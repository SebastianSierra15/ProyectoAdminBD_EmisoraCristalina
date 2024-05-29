using Microsoft.AspNetCore.Mvc;
using ProyectoAdmin_EmisoraCristalina.Data;
using ProyectoAdmin_EmisoraCristalina.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using DinkToPdf;
using Microsoft.AspNetCore.Http.Extensions;
using DinkToPdf.Contracts;
using Org.BouncyCastle.Utilities;
using WebReservas.Data;
using MongoDB.Bson;
using System;

namespace ProyectoAdmin_EmisoraCristalina.Controllers
{
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

        public IActionResult Crear(IFormCollection form)
        {
            var fechaInicio = form["fechaInicio"];
            var fechaFin = form["fechaFin"];
            var cuniasNombre = form["cunia[][nombre]"];
            var cuniasDescripcion = form["cunia[][descripcion]"];
            var cuniasTarifa = form["cunia[][tarifa]"];

            var user = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            string id = cn.AgregarContrato(form["nombre"] + "", fechaInicio, fechaFin, form["anunciante"] + "", form["valor"] + "", user + "");

            for (int i = 0; i < cuniasNombre.Count; i++)
            {
                cn.AgregarCunia(cuniasNombre[i] + "", cuniasDescripcion[i] + "", cuniasTarifa[i] + "", id);
            }

            id = (id + "," + cuniasNombre.Count);

            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Contrato/VistaPDF/{id}";

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
            }

            return file;
        }

        public IActionResult DescargarPDF(string id)
        {
            ObjectId idPDF = new ObjectId(id);
            byte[] contenidoPDF = mongo.ObtenerPDF(idPDF);

            return File(contenidoPDF, "application/pdf", "Contrato.pdf");
        }

        [HttpPost]
        public IActionResult BuscarTarifa(string id)
        {
            TarifaModel tarifa = cn.BuscarTarifa(id);

            return Json(tarifa);
        }
    }
}
