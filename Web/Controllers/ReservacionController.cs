using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Permisos;
using Web.Utils;

namespace Web.Controllers
{
    public class ReservacionController : Controller
    {
        // GET: Reservacion
        [CustomAuthorize((int)Roles.Admin)]
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

                ViewBag.EstadoReservacion = listaEstadoReservacion();

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
        [CustomAuthorize((int)Roles.Residente)]
        public ActionResult IndexUsuario()
        {
            try
            {

                Usuario usuario = (Usuario)Session["Usuario"];
                IServiceReservacion _Service = new ServiceReservacion();
                ViewBag.listaAreas = listaAreas();
                ViewBag.listaReservacion = _Service.GetAllByIdUsuario(usuario.Id);
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

        [HttpPost]
        public ActionResult Save(Reservacion oReservacion)
        {
            IServiceReservacion _Service = new ServiceReservacion();
            try
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                oReservacion.FK_Usuario = usuario.Id;
                oReservacion.FK_Estado = 1;
                if (ModelState.IsValid)
                {
                    if (_Service.Save(oReservacion) > 0)
                    {
                        ViewBag.listaReservacion = _Service.GetAllByIdUsuario(usuario.Id);
                        return RedirectToAction("IndexUsuario");
                    }
                    else
                    {
                    }

                }
                else
                {
                    ViewBag.listaAreas = listaAreas();
                    ViewBag.listaReservacion = _Service.GetAllByIdUsuario(usuario.Id);
                    return View("IndexUsuario",oReservacion);

                }
                return RedirectToAction("Index");          
  
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
        public JsonResult ValidarHorario(DateTime fechaEntrada, DateTime fechaSalida, int idAreaComunal)
        {
            try
            {


                IServiceReservacion _Service = new ServiceReservacion();
                bool existeHorario = _Service.ValidarHorario(fechaEntrada, fechaSalida,idAreaComunal);
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

        [HttpPost]
        public ActionResult CambiarEstado(int id, string nota, int idEstado = 4 ) //Si no viene, cancelada por usuario
        {
            try
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                IServiceReservacion _Service = new ServiceReservacion();
                IServiceNotificacionUsuario _ServiceNotificaion = new ServiceNotificacionUsuario();
                IEnumerable<Reservacion> lista = null;
                _Service.CambiarEstado(id, nota,idEstado);
                if(usuario.FK_Rol == 1)
                {
                    _ServiceNotificaion.SaveNotificacionUsuario(new NotificacionUsuario { IdNotificacion = 4, IdUsuario = _Service.GetByIdReservacion(id).FK_Usuario, Leida=false });

                    lista = _Service.GetAll();
                    
                }
                else
                {
                    lista = _Service.GetAllByIdUsuario(usuario.Id);
                }
                 return PartialView("~/Views/Shared/Reservacion/_Reservacion.cshtml", lista);

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