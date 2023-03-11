﻿using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class AutentificacionController : Controller
    {
        // GET: Autentificacion
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            int facturasPendientes = 0;
            IServiceAutentificacion service = new ServiceAutentificacion();
            IServiceNotificacionUsuario _ServiceNotificacionUsuario = new ServiceNotificacionUsuario();
            
            oUsuario = service.Login(oUsuario.Email, oUsuario.Clave);
            if (oUsuario != null)
            {
                IEnumerable<NotificacionUsuario> listaNotificaciones = _ServiceNotificacionUsuario.GetNotificacionByIdUser(oUsuario.Id);
                if(listaNotificaciones != null)
                {
                    Session["Notificaciones"] = listaNotificaciones;
                }
                FormsAuthentication.SetAuthCookie(oUsuario.Email, true);

                Session["Usuario"] = oUsuario;
                
                return RedirectToAction("IndexAdmin", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

        }

    }
}