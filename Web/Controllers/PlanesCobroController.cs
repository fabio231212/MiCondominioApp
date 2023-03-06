using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.IdRubro = listaRubro();
            return View();
        }

        [HttpGet]
        public ActionResult GetPrecioRubro(int rubroId)
        {
            IServiceRubroCobro _ServiceRubro = new ServiceRubroCobro();
            var rubro = _ServiceRubro.GetRubroById(rubroId);
            return Json(new { precio = rubro.Costo }, JsonRequestBehavior.AllowGet);
        }

        private MultiSelectList listaRubro(ICollection<RubroCobro> rubros = null)
        {
            IServiceRubroCobro _ServiceRubro = new ServiceRubroCobro();
            IEnumerable<RubroCobro> lista = _ServiceRubro.GetAll();
            //Seleccionar categorias
            int[] listaRubrosSeleccionados= null;
            if (rubros != null)
            {
                listaRubrosSeleccionados = rubros.Select(c => c.Id).ToArray();
            }

            return new MultiSelectList(lista, "Id", "Descripcion", listaRubrosSeleccionados);
        }

        // GET: PlanesCobro/Edit/5
        public ActionResult Edit(int? id)
        {
            IServicePlanCobro _ServicePlan = new ServicePlanCobro();
            PlanCobro plan = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                plan = _ServicePlan.GetById(Convert.ToInt32(id));
                if (plan == null)
                {
                    TempData["Message"] = "No existe el plan solicitado";
                    TempData["Redirect"] = "PlanesCobro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Listados
                ViewBag.IdRubro = listaRubro(plan.RubroCobro);
                return View(plan);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "PlanesCobros";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // POST: PlanesCobro/Edit/5
        [HttpPost]
        public ActionResult Save(PlanCobro plan, string[] rubrosSeleccionados)
        {

            //Servicio Libro
            IServicePlanCobro _ServicePlan = new ServicePlanCobro();
            try
            {

                if (ModelState.IsValid)
                {
                 _ServicePlan.SaveOrUpdate(plan, rubrosSeleccionados);
                }
                else
                {
                    ViewBag.IdRubro = listaRubro(plan.RubroCobro);
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (plan.Id > 0)
                    {
                        return (ActionResult)View("Edit", plan);
                    }
                    else
                    {
                        return View("Create", plan);
                    }
                }

                return RedirectToAction("Index");
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
