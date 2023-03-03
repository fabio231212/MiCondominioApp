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
    [Authorize]
    public class PlanesCobroController : Controller
    {
        // GET: PlanesCobro
        public ActionResult Index()
        {
            IEnumerable<PlanCobro> lista = null;
            try
            {
                IServicePlanCobro _Service = new ServicePlanCobro();
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

        // GET: PlanesCobro/Details/5
        public ActionResult Details(int id)
        {
            PlanCobro oPlan = null;
            try
            {
                IServicePlanCobro _Service = new ServicePlanCobro();
                oPlan = _Service.GetById(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
            return View(oPlan);
        }

        // GET: PlanesCobro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanesCobro/Create
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

        // GET: PlanesCobro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanesCobro/Edit/5
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

        // GET: PlanesCobro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanesCobro/Delete/5
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
