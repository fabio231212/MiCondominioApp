using ApplicationCore.Services;
using Infraestructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PropiedadController : Controller
    {
        // GET: Propiedad
        public ActionResult Index()
        {
            IEnumerable<Propiedad> lista = null;
            try
            {
                IServicePropiedad _ServicePropiedad = new ServicePropiedad();
                lista = _ServicePropiedad.GetAll();
                ViewBag.Title = "Lista Propiedad";
                return View(lista);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: Propiedad/Details/5

        public ActionResult Details(string id)
        {
            Propiedad oPropiedad = null;
            try
            {
                IServicePropiedad _ServicePropiedad = new ServicePropiedad();
                oPropiedad = _ServicePropiedad.GetPropiedadByNumProp(id.Trim());
                return View(oPropiedad);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: Propiedad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propiedad/Create
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

        // GET: Propiedad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Propiedad/Edit/5
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

        // GET: Propiedad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Propiedad/Delete/5
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
