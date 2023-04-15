using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ArchivoController : Controller
    {
        private readonly IServiceArchivo _Service;

        public ArchivoController() => _Service = new ServiceArchivo();

        // GET: Archivo
        public ActionResult Index()
        {
            IEnumerable<Archivo> lista = _Service.GetAll();
            return View(lista);
        }

        [HttpPost]
        public ActionResult CargarPDF(HttpPostedFileBase archivo)
        { 
            if (archivo != null && archivo.ContentLength > 0)
            {
                //Leer archivo PDF desde el stream y guardarlo en una variable
                var archivoPDF = new byte[archivo.ContentLength];
                archivo.InputStream.Read(archivoPDF, 0, archivo.ContentLength);

                //Crear nueva entidad ArchivoPDF y asignar el archivo al contenido PDF
                Archivo nuevoArchivo = new Archivo { Nombre=archivo.FileName,Contenido = archivoPDF };
                _Service.Save(nuevoArchivo);

            }

            return RedirectToAction("Index");
        }

        public ActionResult DescargarPDF(int id)
        {
            //Seleccionar la entidad ArchivoPDF correspondiente al ID de la solicitud
            Archivo oArchivo = _Service.Get(id);

            if (oArchivo == null)
            {
                return HttpNotFound();
            }

            //Devolver el archivo PDF como un archivo para descargar
            return File(oArchivo.Contenido, "application/pdf", $"{oArchivo.Nombre}.pdf");
        }
    }
}