﻿using ApplicationCore.Services;
using Infraestructure.Models;
using System;
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
    public class RubroCobroController : Controller
    {
        private readonly IServiceRubroCobro _Service;

        public RubroCobroController() => _Service = new ServiceRubroCobro();

        [CustomAuthorize((int)Roles.Admin)]
        // GET: RubroCobro
        public ActionResult Index()
        {
            IEnumerable<RubroCobro> lista = null;
            try
            {
                lista = _Service.GetAll();
                ViewBag.Title = "Lista Rubros";
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

        // GET: RubroCobro/Details/5
        public ActionResult Details(int id) => View();
        

        // GET: RubroCobro/Create
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Create() => View();
        

        // GET: RubroCobro/Edit/5
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Edit(int? id)
        {
            RubroCobro oRubro = null;

            try
            {
                if (id == null)
                {
                    TempData["Message"] = "El ID no puede ser nulo";
                    return RedirectToAction("Index");
                }

                oRubro = _Service.GetRubroById(Convert.ToInt32(id));

                if (oRubro == null)
                {
                    TempData["Message"] = "No existe el rubro solicitado";
                    TempData["Redirect"] = "RubroCobro";
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
                TempData["Redirect"] = "Home";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RubroCobro rubro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Service.SaveOrUpdate(rubro);

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
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Home";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }


    }
}
