
using ApplicationCore.Services;
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
    public class InformacionController : Controller
    {
        private readonly IServiceInformacion _Service;

        public InformacionController() => _Service = new ServiceInformacion();

        // GET: Informacion
        public ActionResult Index() => View();


        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Create() =>  View();
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Informacion oInformacion)
        {         
                try
                {
                    if (ModelState.IsValid)
                    {
                        _Service.Create(oInformacion);

                    }
                    else
                    {
                        if (oInformacion.Id == 0)
                        {
                            return View("Create", oInformacion);
                        }
                        else
                        {
                            return View("Edit", oInformacion);
                        }

                    }
                    return RedirectToAction("IndexAdmin","Home");

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
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Edit(int? id)
        {
            Informacion oInformacion = null;

            try
            {
                if (id == null)
                {
                    TempData["Message"] = "El ID no puede ser nulo";
                    return View();
                }

                oInformacion = _Service.GetById(Convert.ToInt32(id));

                if (oInformacion == null)
                {
                    TempData["Message"] = "No existe la información solicitada";
                    TempData["Redirect"] = "Informacion";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                return View(oInformacion);

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