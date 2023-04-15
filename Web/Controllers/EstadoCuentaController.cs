using Antlr.Runtime.Misc;
using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web.Permisos;
using Web.Utils;

namespace Web.Controllers
{
    //[Authorize]
    public class EstadoCuentaController : Controller
    {
        private readonly IServiceEstadoCuenta _Service;

        public EstadoCuentaController() => _Service = new ServiceEstadoCuenta();

        [CustomAuthorize((int)Roles.Admin)]

        // GET: EstadoCuenta/Details/5
        public ActionResult Index(int? id, bool? active)
        {

            try
            {
                IEnumerable<Factura> lista = null;

                if (active.HasValue)
                {
                    lista = _Service.GetEstadoCuentaByFilter((bool)active, (int)id);
                }
                else
                {
                    lista = _Service.GetByIdProp((int)id);
                }

                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        
    }

        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult EstadosCuentaPendientes()
        {
            IEnumerable<Factura> lista = null;
            try
            {
                lista = _Service.GetEstadoCuentaPendiente();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }


        }
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult DetalleEstadoCuenta(int idEstadoCuenta)
        {
            Factura oFactura = null;
            try
            {
                oFactura = _Service.GetDetalleEstadoCuenta(idEstadoCuenta);
                return View(oFactura);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }
        [CustomAuthorize((int)Roles.Admin)]
        // GET: EstadoCuenta/Create
        public ActionResult Create()
        {
            ViewBag.idPropiedad = listaPropiedades();
            ViewBag.idPlanCobro = listaPlanCobro();
            ViewBag.listaFacturasXMes = _Service.GetFacturasByFecha();
            return View();
    }


        // GET: EstadoCuenta/Edit/5
        public ActionResult Edit(int id) => View();

        // POST: EstadoCuenta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Factura factura)
        {
            try
            {
                IServiceEstadoCuenta _ServiceEstadoCuenta = new ServiceEstadoCuenta();
                try
                {
                    IServiceNotificacionUsuario _ServiceNotificaion = new ServiceNotificacionUsuario();
                    IServicePropiedad _ServicePropiedad = new ServicePropiedad();
                    ModelState.Remove("FechaFacturacion");
                    ModelState.Remove("Tarjeta");
                    ModelState.Remove("Activo");

                    if (ModelState.IsValid)
                    {
                        factura.Activo = true;
                        factura.FK_Tarjeta = 1;
                        factura.FechaFacturacion = DateTime.Now;
                        factura.Tarjeta = "1234";

                        IEnumerable<Factura>  listaFacturas = _ServiceEstadoCuenta.GetByIdProp((int)factura.FK_Propiedad);
                        foreach (Factura oFact in listaFacturas)
                        {
                                if (oFact.FechaFacturacion.Value.Month == factura.FechaFacturacion.Value.Month && oFact.FechaFacturacion.Value.Year == factura.FechaFacturacion.Value.Year)
                                {
                                    ViewBag.idPropiedad = listaPropiedades(factura.FK_Propiedad);
                                    ViewBag.idPlanCobro = listaPlanCobro(factura.FK_PlanCobro);
                                    ViewBag.listaFacturasXMes = new ServiceEstadoCuenta().GetFacturasByFecha();
                                    TempData["existe"] = true;
                                    return View("Create", factura);
                                }                           
                        }

                        _ServiceEstadoCuenta.Create(factura);
                        _ServiceNotificaion.SaveNotificacionUsuario(new NotificacionUsuario { IdNotificacion = 5, IdUsuario = (int)_ServicePropiedad.GetPropiedadById((int)factura.FK_Propiedad).FK_Usuario, Leida = false });
                        ViewBag.idPropiedad = listaPropiedades();
                        ViewBag.idPlanCobro = listaPlanCobro();
                        TempData["creada"] = true;
                        return RedirectToAction("Create");

                    }
                    else
                    {
                        if (factura.Propiedad == null)
                        {
                            ViewBag.idPropiedad = listaPropiedades();
                        }
                        else
                        {
                            ViewBag.idPropiedad = listaPropiedades(factura.FK_Propiedad);
                        }

                        if (factura.PlanCobro == null)
                        {
                            ViewBag.idPlanCobro = listaPlanCobro();
                        }
                        else
                        {
                            ViewBag.idPlanCobro = listaPlanCobro(factura.FK_PlanCobro);
                        }
                        ViewBag.listaFacturasXMes = new ServiceEstadoCuenta().GetFacturasByFecha();
                        return View("Create", factura);                     
                    }
                }

                catch (Exception ex)
                {
                    // Salvar el error en un archivo 

                    TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                    TempData["Redirect"] = "Home";
                    TempData["Redirect-Action"] = "IndexAdmin";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
            }
            catch
            {
                return View();
            }
        }



        public SelectList listaPropiedades(int? id = 0)
        {
            IServicePropiedad _ServicePropiedad = new ServicePropiedad();
            IEnumerable<Propiedad> lista = _ServicePropiedad.GetAll();
            return new SelectList(lista, "Id", "NumPropiedad", id);
        }

        public SelectList listaPlanCobro(int? id = 0)
        {
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            IEnumerable<PlanCobro> lista = _ServicePlanCobro.GetAll();
            return new SelectList(lista, "Id", "Descripcion", id);
        }

        public ActionResult GetPlanById(int id)
        {
            IServicePlanCobro _ServicePlan = new ServicePlanCobro();
             PlanCobro plan = _ServicePlan.GetById(id);
            return Json(new { data = plan.Total }, JsonRequestBehavior.AllowGet);

        }

    }
}
