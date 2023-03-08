using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class IncidenciaController : Controller
    {
        // GET: Incidencia
        public ActionResult IndexAdmin(int? EstadoIncidencia)
        {
            IServiceIncidencias _Service = new ServiceIncidencias();
            IEnumerable<Incidencias> lista = null;
            if (EstadoIncidencia != null)
            {
                lista = _Service.GetByIdEstado((int)EstadoIncidencia);
            }
            else
            {
                lista = _Service.GetAll();
            }

            ViewBag.listaEstadoIncidencia = listaEstadoIncidencia();

            return View(lista);
           
        }
        public ActionResult IndexUsuario()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            IServiceIncidencias _Service = new ServiceIncidencias();
            IEnumerable<Incidencias> lista = _Service.GetByIdUser(usuario.Id);
            return View(lista);
        }


        public ActionResult CambiarEstado(int id, string estado)
        {
            IServiceIncidencias _Service = new ServiceIncidencias();
            IEnumerable<Incidencias> lista = null;
            if (_Service.ActualizarEstadoIncidencia(id, int.Parse(estado)) >= 0)
            {
                lista = _Service.GetAll();
                return PartialView("~/Views/Shared/Incidencias/_ListaActualizada.cshtml",lista);
            }
            return View();
           
        }



        public ActionResult CrearIncidencia(string descripcion)
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            IServiceIncidencias _Service = new ServiceIncidencias();
            if (!String.IsNullOrEmpty(descripcion))
            {
                Incidencias oIncidencia = new Incidencias { Descripcion = descripcion, FK_Usuario = usuario.Id, Fecha = DateTime.Now,FK_Estado=1};
                if (_Service.RegistrarIncidencia(oIncidencia) > 0)
                {
                    IEnumerable<Incidencias> lista = _Service.GetByIdUser(usuario.Id);
                    return PartialView("~/Views/Shared/Incidencias/_Incidencias.cshtml", lista);
                }
            }
            return View();
         

        }

        private SelectList listaEstadoIncidencia(int? idEstado = 0)
        {
            IServiceEstadoIncidencia _Service = new ServiceEstadoIncidencia();
            IEnumerable<EstadoIncidencia> lista = _Service.GetAll();
            return new SelectList(lista, "Id", "Nombre",idEstado);
        }

    


    }
}