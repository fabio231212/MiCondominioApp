using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web.Utils;

namespace Web.Controllers
{
    public class NotificacionUsuarioController : Controller
    {
        private readonly IServiceNotificacionUsuario _Service;

        public NotificacionUsuarioController() => _Service = new ServiceNotificacionUsuario();

        // GET: NotificacionUsuario
        public ActionResult Index() => View();
        
        public PartialViewResult marcarLeido(int idNotificacion, int idUsuario)
        {    
            NotificacionUsuario oNotificacion = _Service.MarcarLeido(idNotificacion);
            IEnumerable<NotificacionUsuario> listaNotificaciones = _Service.GetNotificacionByIdUser(idUsuario);
            Session["Notificaciones"] = listaNotificaciones;
            return PartialView("_Notificaciones", listaNotificaciones);
        }


        public void SaveNotificacion(int idUsuario,int? idNotificacion=3)
        {
            try
            {

            NotificacionUsuario oNotificacionUsuario = new NotificacionUsuario { IdNotificacion= (int)idNotificacion,IdUsuario=idUsuario,Leida=false }; 

            if (ModelState.IsValid)
            {
                _Service.SaveNotificacionUsuario(oNotificacionUsuario);
            }
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                RedirectToAction("Default", "Error");
            }

        }
    }
}