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
    public class RubroCobroController : Controller
    {
        // GET: RubroCobro
        public ActionResult Index()
        {
            IEnumerable<RubroCobro> lista = null;
            try
            {
                IServiceRubroCobro _ServiceRubro = new ServiceRubroCobro();
                lista = _ServiceRubro.GetAll();
                ViewBag.Title = "Lista Rubros";
                return View(lista);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: RubroCobro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RubroCobro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RubroCobro/Create
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

        // GET: RubroCobro/Edit/5
        public ActionResult Edit(int? id)
        {
            IServiceRubroCobro _ServiceRubro = new ServiceRubroCobro();
            RubroCobro oRubro = null;

            try
            {
                if (id == null)
                {
                    TempData["Message"] = "El ID no puede ser nulo";
                    return RedirectToAction("Index");
                }

                oRubro = _ServiceRubro.GetRubroById(Convert.ToInt32(id));

                if (oRubro == null)
                {
                    TempData["Message"] = "No existe el rubro solicitado";
                    TempData["Redirect"] = "Usuario";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(oRubro);

            }
            catch (Exception ex)
            {

                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


        [HttpPost]
        public ActionResult Save(RubroCobro rubro)
        {
            IServiceRubroCobro _ServiceRubro = new ServiceRubroCobro();
            try
            {
                if (ModelState.IsValid)
                {
                    _ServiceRubro.SaveOrUpdate(rubro);

                }
                else
                {
                    if (rubro.Id == 0)
                    {
                        return View("Create", rubro);
                    }
                    else
                    {
                        return View("Edit", rubro);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RubroCobro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RubroCobro/Delete/5
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
