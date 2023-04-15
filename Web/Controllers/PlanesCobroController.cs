using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web.Permisos;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class PlanesCobroController : Controller
    {
        private readonly IServicePlanCobro _Service;

        public PlanesCobroController() => _Service = new ServicePlanCobro();

        // GET: PlanesCobro
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Index()
        {
            IEnumerable<PlanCobro> lista = null;
            try
            {
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

        [CustomAuthorize((int)Roles.Admin)]

        // GET: PlanesCobro/Details/5
        public ActionResult Details(int id)
        {
            PlanCobro oPlan = null;
            try
            {
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


        private MultiSelectList listaRubro(ICollection<RubroCobro> rubros = null)
        {
            IServiceRubroCobro _ServiceRubro = new ServiceRubroCobro();
            IEnumerable<RubroCobro> lista = _ServiceRubro.GetAll();

            // Agregar precios a la lista de rubros
            var rubrosConPrecios = lista.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = $"{r.Descripcion} - ₡{r.Costo}"
            });

            // Obtener los IDs de los rubros seleccionados
            int[] listaRubrosSeleccionados = null;
            if (rubros != null)
            {
                listaRubrosSeleccionados = rubros.Select(c => c.Id).ToArray();
            }

            return new MultiSelectList(rubrosConPrecios, "Value", "Text", listaRubrosSeleccionados);
        }


        // GET: PlanesCobro/Edit/5
        public ActionResult Edit(int? id)
        {
            PlanCobro plan = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                plan = _Service.GetById(Convert.ToInt32(id));
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
                TempData["Redirect"] = "PlanesCobro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // POST: PlanesCobro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PlanCobro plan, string[] rubrosSeleccionados)
        {
            try
            {

                if (ModelState.IsValid)
                {
                 _Service.SaveOrUpdate(plan, rubrosSeleccionados);
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
                TempData["Redirect"] = "PlanesCobro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


    }
}
