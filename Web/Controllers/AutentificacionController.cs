﻿using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using Web.Utils;

namespace Web.Controllers
{
    public class AutentificacionController : Controller
    {
        private readonly IServiceAutentificacion _ServiceAutentificacion;
        private readonly IServiceNotificacionUsuario _ServiceNotificacion;

        public AutentificacionController() {
            _ServiceAutentificacion = new ServiceAutentificacion();
            _ServiceNotificacion = new ServiceNotificacionUsuario();
        }


        // GET: Autentificacion
        public ActionResult Login() => View();
        

        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {

            try
            {


                ModelState.Remove("Nombre");
                ModelState.Remove("Apellido1");
                ModelState.Remove("Apellido2");
                ModelState.Remove("Cedula");
                ModelState.Remove("FK_Rol");
                ModelState.Remove("Activo");
                if (ModelState.IsValid)
                {
                    oUsuario = _ServiceAutentificacion.Login(oUsuario.Email, oUsuario.Clave);

                    if (oUsuario != null)
                    {
                        if (oUsuario.Activo == false)
                        {
                            ViewData["Mensaje"] = "El usuario se encuentra inactivo";
                            return View();
                        }
                        IEnumerable<NotificacionUsuario> listaNotificaciones = _ServiceNotificacion.GetNotificacionByIdUser(oUsuario.Id);
                        if (listaNotificaciones != null)
                        {
                            Session["Notificaciones"] = listaNotificaciones;
                        }
                        FormsAuthentication.SetAuthCookie(oUsuario.Email, true);

                        Session["Usuario"] = oUsuario;
                        if (oUsuario.FK_Rol == 1)
                        {
                            return RedirectToAction("IndexAdmin", "Home");
                        }
                        else
                        {
                            return RedirectToAction("IndexUsuario", "Home");
                        }

                    }
                    else
                    {
                        ViewData["Mensaje"] = "Usuario no encontrado";
                        return View();
                    }
            }
                else
            {
                ViewData["Mensaje"] = "Algún dato no coincide o no fue digitado.";
                return View();
            }
        }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }


        }

        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "No autorizado";
            if (Session["User"] != null)
            {
                Usuario usuario = Session["User"] as Usuario;
                Log.Warn($"No autorizado {usuario.Email}");
            }
            return View();
        }

    }
}