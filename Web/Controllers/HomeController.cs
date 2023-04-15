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

    public class HomeController : Controller
    {

        private readonly IServiceInformacion _ServiceInfo;
        private readonly IServiceArchivo _ServiceArchivo;
        private readonly IServiceEstadoCuenta _ServiceEstadoCuenta;
        private readonly IServiceHomeInfo _ServiceHomeInfo;

        public HomeController()
        {
            _ServiceArchivo= new ServiceArchivo();
            _ServiceEstadoCuenta= new ServiceEstadoCuenta();
            _ServiceInfo = new ServiceInformacion();
            _ServiceHomeInfo = new ServiceHomeInfo();
        }


        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult IndexAdmin() => View();
        

        [CustomAuthorize((int)Roles.Residente)]
        public ActionResult IndexUsuario()
        {
            ViewBag.listaInformacion = _ServiceInfo.GetAll();
            ViewBag.listaArchivos =  _ServiceArchivo.GetAll();

            return View();
        }

        public ActionResult About() => View();

        public ActionResult Contact() => View();
        

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
            IEnumerable<TotalesPorMesDTO> listaTotalesFactura = _ServiceHomeInfo.GetTotalFacturaPorMes(_ServiceEstadoCuenta.GetAll());
            IEnumerable<DeudasVigentesDTO> listaDeudas = _ServiceHomeInfo.GetCantFacPendientes(_ServiceEstadoCuenta.GetAll());
            cantIncidencias = _ServiceHomeInfo.cantidadIncidencias();
            totalGanancias = (double)listaTotalesFactura.Sum(f => f.Total);
            cantDeudas = listaDeudas.Sum(d => d.Cantidad);


            return Json(new { lista = listaTotalesFactura,listaDeudas=listaDeudas, totalGanancias = totalGanancias,cantIncidencias = cantIncidencias, cantDeudas= cantDeudas }, JsonRequestBehavior.AllowGet);
        }
    }
}