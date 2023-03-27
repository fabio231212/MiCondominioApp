using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    public class ReservacionController : Controller
    {
        // GET: Reservacion
        public ActionResult IndexAdmin(int? estado)
        {
            try
            {

                IServiceReservacion _Service = new ServiceReservacion();
                IEnumerable<Reservacion> lista = null;
                if (estado != null)
                {
                    lista = _Service.GetByEstado((int)estado);
                }
                else
                {
                    lista = _Service.GetAll();
                }

                ViewBag.listaEstadoReservacion = listaEstadoReservacion();

                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }


        }

        public ActionResult IndexUsuario()
        {
            try
            {

                Usuario usuario = (Usuario)Session["Usuario"];
                IServiceReservacion _Service = new ServiceReservacion();
                IEnumerable<Reservacion> lista = _Service.GetByIdUsuario(usuario.Id);
                ViewBag.listaAreas = listaAreas();
                ViewBag.listaReservacion = _Service.GetAll();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        [HttpPost]
        public ActionResult Save(Reservacion oReservacion)
        {
            try
            {


                Usuario usuario = (Usuario)Session["Usuario"];
                IServiceReservacion _Service = new ServiceReservacion();
                if (oReservacion != null)
                {
                    oReservacion.FK_Estado = 1;
                    oReservacion.FK_AreaComunal = 1;
                    oReservacion.FK_Usuario = usuario.Id;
                    if (_Service.Save(oReservacion) > 0)
                    {
                        IEnumerable<Reservacion> lista = _Service.GetByIdUsuario(usuario.Id);
                        return PartialView("~/Views/Shared/Reservacion/_Reservacion.cshtml", lista);
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }


        }

        private SelectList listaEstadoReservacion(int? idEstado = 0)
        {

            IServiceEstados<EstadoReservacion> _Service = new ServiceEstadoReservacion();
            IEnumerable<EstadoReservacion> lista = _Service.GetAll();
            return new SelectList(lista, "Id", "Nombre", idEstado);
        }
        [HttpGet]
        public JsonResult ValidarHorario(string fechaEntrada, string fechaSalida)
        {
            try
            {


                IServiceReservacion _Service = new ServiceReservacion();
                bool existeHorario = _Service.ValidarHorario(DateTime.Parse(fechaEntrada), DateTime.Parse(fechaSalida));
                return Json(new { existeHorario = existeHorario }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SelectList listaAreas(int? id = 0)
        {
            IServiceAreaComunal _Service = new ServiceAreaComunal();
            IEnumerable<AreaComunal> lista = _Service.GetAll();
            return new SelectList(lista, "Id", "Nombre", id);

        }

        public ActionResult GetHorarioById(int id)
        {
            IServiceAreaComunal _Service = new ServiceAreaComunal();
            AreaComunal oArea = null;
            try
            {
                oArea = _Service.GetAreaComunalById(id);
                return Json(new {horaApertura = oArea.HoraApertura.Value.ToString(), horaCierre = oArea.HoraCierre.Value.ToString()}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
    }
}