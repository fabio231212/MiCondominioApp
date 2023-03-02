using ApplicationCore.Services;
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
            oUsuario = service.Login(oUsuario.Email, oUsuario.Clave);
            foreach (Propiedad itemProp in oUsuario.Propiedad)
            {
                foreach (Factura itemFac in itemProp.Factura)
                {
                    if ((bool)itemFac.Activo)
                    {
                        facturasPendientes++;
                    }
                }
            }
            if (oUsuario != null)
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Email, true);

                Session["Usuario"] = oUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

        }

    }
}