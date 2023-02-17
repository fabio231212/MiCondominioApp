using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    public class EstadoCuentaController : Controller
    {
        // GET: EstadoCuenta
        public ActionResult Index()
        {
            IEnumerable<Factura> lista = null;
            try
            {
                IServiceEstadoCuenta _Service = new ServiceEstadoCuenta();
                lista = _Service.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
            return View(lista);
        }

        // GET: EstadoCuenta/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<Factura> lista = null;
            try
            {
                IServiceEstadoCuenta _Service = new ServiceEstadoCuenta();
                lista = _Service.GetbyIdUsuario(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
            return View(lista);
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
