using Antlr.Runtime.Misc;
using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class EstadoCuentaController : Controller
    {

        // GET: EstadoCuenta/Details/5
        public ActionResult Index(int? id, bool? active)
        {

            try
            {

                IServiceEstadoCuenta _Service = new ServiceEstadoCuenta();
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


        public ActionResult EstadosCuentaPendientes()
        {
            IEnumerable<Factura> lista = null;
            try
            {
                IServiceEstadoCuenta _Service = new ServiceEstadoCuenta();
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

        public ActionResult DetalleEstadoCuenta(int idEstadoCuenta)
        {
            Factura oFactura = null;
            try
            {
                IServiceEstadoCuenta _Service = new ServiceEstadoCuenta();
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

        // GET: EstadoCuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoCuenta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoCuenta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadoCuenta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoCuenta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadoCuenta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
