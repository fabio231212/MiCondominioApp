using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class NotificacionUsuarioController : Controller
    {
        // GET: NotificacionUsuario
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult marcarLeido(int idNotificacion, int idUsuario)
        {

            IServiceNotificacionUsuario serviceNotificacionUsuario = new ServiceNotificacionUsuario();
            NotificacionUsuario oNotificacion = serviceNotificacionUsuario.MarcarLeido(idNotificacion);
            IEnumerable<NotificacionUsuario> listaNotificaciones = serviceNotificacionUsuario.GetNotificacionByIdUser(idUsuario);
            Session["Notificaciones"] = listaNotificaciones;
            return PartialView("_Notificaciones", listaNotificaciones);
        }


        public void SaveNotificacion(int idUsuario,int? idNotificacion=3)
        {
            NotificacionUsuario oNotificacionUsuario = new NotificacionUsuario { IdNotificacion= (int)idNotificacion,IdUsuario=idUsuario,Leida=false }; 
            IServiceNotificacionUsuario serviceNotificacionUsuario = new ServiceNotificacionUsuario();
            int result = serviceNotificacionUsuario.SaveNotificacionUsuario(oNotificacionUsuario);

        }
    }
}