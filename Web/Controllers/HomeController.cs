using ApplicationCore.Services;
using Infraestructure.Models;
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
        public ActionResult IndexUsuario()
        {
            IServiceInformacion _ServiceInfo = new ServiceInformacion();
            ViewBag.listaInformacion = _ServiceInfo.GetAll();
            IServiceArchivo _ServiceArchivo = new ServiceArchivo();
            ViewBag.listaArchivos =  _ServiceArchivo.GetAll();

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
            double totalGanancias = 0;
            int cantDeudas = 0;
            int cantIncidencias = 0;
            IServiceHomeInfo serviceHomeInfo = new ServiceHomeInfo();
            IServiceEstadoCuenta serviceEstadoCuenta = new ServiceEstadoCuenta();
            IEnumerable<TotalesPorMesDTO> listaTotalesFactura = serviceHomeInfo.GetTotalFacturaPorMes(serviceEstadoCuenta.GetAll());
            IEnumerable<DeudasVigentesDTO> listaDeudas = serviceHomeInfo.GetCantFacPendientes(serviceEstadoCuenta.GetAll());
            cantIncidencias = serviceHomeInfo.cantidadIncidencias();
            totalGanancias = (double)listaTotalesFactura.Sum(f => f.Total);
            cantDeudas = listaDeudas.Sum(d => d.Cantidad);


            return Json(new { lista = listaTotalesFactura,listaDeudas=listaDeudas, totalGanancias = totalGanancias,cantIncidencias = cantIncidencias, cantDeudas= cantDeudas }, JsonRequestBehavior.AllowGet);
        }
    }
}