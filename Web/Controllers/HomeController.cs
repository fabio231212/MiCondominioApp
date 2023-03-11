using ApplicationCore.Services;
using Infraestructure.Models.DTO;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using Web.Permisos;

namespace Web.Controllers
{
    [Authorize]
    [ValidarSesion]
    public class HomeController : Controller
    {
        public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Autentificacion");
        }

        public JsonResult getHomeInfo()
        {
            int cantIncidencias = 0;
            IServiceHomeInfo serviceHomeInfo = new ServiceHomeInfo();
            IServiceEstadoCuenta serviceEstadoCuenta = new ServiceEstadoCuenta();
            IEnumerable<TotalesPorMesDTO> lista = serviceHomeInfo.GetTotalFacturaPorMes(serviceEstadoCuenta.GetAll());
            cantIncidencias = serviceHomeInfo.cantidadIncidencias();
            List<string> listaMeses = new List<string>();
            List<decimal> listaTotales = new List<decimal>();
            decimal total = 0;
            foreach (TotalesPorMesDTO item in lista)
            {
                DateTimeFormatInfo monthInfo = new DateTimeFormatInfo();
                listaMeses.Add(monthInfo.GetMonthName(item.Mes));
                listaTotales.Add(item.Total);
                total += item.Total;
            }
           
            return Json(new { listaMeses = listaMeses,listaTotales=listaTotales,total=total, cantIncidencias = cantIncidencias}, JsonRequestBehavior.AllowGet);
        }
    }
}