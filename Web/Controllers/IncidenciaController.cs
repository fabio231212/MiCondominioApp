using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class IncidenciaController : Controller
    {
        // GET: Incidencia
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult IndexUsuario()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            IServiceIncidencias _Service = new ServiceIncidencias();
            IEnumerable<Incidencias> lista = _Service.GetByIdUser(usuario.Id);
            return View(lista);
        }

        public ActionResult CrearIncidencia(string descripcion)
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            IServiceIncidencias _Service = new ServiceIncidencias();
            if (!String.IsNullOrEmpty(descripcion))
            {
                Incidencias oIncidencia = new Incidencias { Descripcion = descripcion, FK_Usuario = usuario.Id, Fecha = DateTime.Now};
                if (_Service.RegistrarIncidencia(oIncidencia) > 0)
                {
                    IEnumerable<Incidencias> lista = _Service.GetByIdUser(usuario.Id);
                    return PartialView("~/Views/Shared/Incidencias/_Incidencias.cshtml", lista);
                }
            }
            return View();
         

        }


    }
}