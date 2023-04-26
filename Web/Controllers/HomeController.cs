using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Models.DTO;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using Web.Permisos;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {

        private readonly IServiceInformacion _ServiceInfo;
        private readonly IServiceArchivo _ServiceArchivo;
        private readonly IServiceEstadoCuenta _ServiceEstadoCuenta;
        private readonly IServiceHomeInfo _ServiceHomeInfo;
        private readonly IServiceReporte _ServiceReporte;

        public HomeController()
        {
            _ServiceArchivo= new ServiceArchivo();
            _ServiceEstadoCuenta= new ServiceEstadoCuenta();
            _ServiceInfo = new ServiceInformacion();
            _ServiceHomeInfo = new ServiceHomeInfo();
            _ServiceReporte = new ServiceReporte();
        }


        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult IndexAdmin()
        {
            ViewBag.idPropiedad = listaPropiedades();
            return View();
        }
        

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

        public SelectList listaPropiedades()
        {
            IServicePropiedad _ServicePropiedad = new ServicePropiedad();
            IEnumerable<Propiedad> lista = _ServicePropiedad.GetAll();
            return new SelectList(lista, "Id", "NumPropiedad");
        }

        [HttpPost]
        public FileResult reporteDeudas(DateTime fechaInicio, DateTime fechaFin, string numPropiedad)
        {
            byte[] pdf = _ServiceReporte.reporteDeudas(fechaInicio, fechaFin, numPropiedad);
            try { 
                if (pdf == null)
                {
                  return null;
                }
                else
                {
                    return File(pdf, "application/pdf", "Reporte de Deudas.pdf");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                RedirectToAction("Default", "Error");
                return null;
            }
        }

        public ActionResult DescargarReporteDeudas()
        {

            try
            {
                return File(Session["reporteDeudas"] as byte[], "application/pdf", "Reporte de Deudas.pdf");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }

        }



    }
}

