using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Utils;

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

            try
            {

                IServiceAutentificacion service = new ServiceAutentificacion();
                IServiceNotificacionUsuario _ServiceNotificacionUsuario = new ServiceNotificacionUsuario();
                //if (ModelState.IsValid)
                //{
                    oUsuario = service.Login(oUsuario.Email, oUsuario.Clave);
                    if (oUsuario != null)
                    {
                        IEnumerable<NotificacionUsuario> listaNotificaciones = _ServiceNotificacionUsuario.GetNotificacionByIdUser(oUsuario.Id);
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
                //}
                //else
                //{
                //    ViewData["Mensaje"] = "Algún dato no coincide o no fue digitado.";
                //    return View();
                //}
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