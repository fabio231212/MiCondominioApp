using ApplicationCore.Services;
using Infraestructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using Web.Permisos;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class PropiedadController : Controller
    {
        private readonly IServicePropiedad _Service;

        public PropiedadController()=> _Service = new ServicePropiedad();

        // GET: Propiedad
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Index()
        {
            IEnumerable<Propiedad> lista = null;
            try
            {
                lista = _Service.GetAll();
                ViewBag.Title = "Lista Propiedad";
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

        // GET: Propiedad/Details/5
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Details(string id)
        {
            Propiedad oPropiedad = null;
            try
            {
                oPropiedad = _Service.GetPropiedadByNumProp(id.Trim());
                return View(oPropiedad);

            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Propiedad";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Propiedad/Create
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Create()
        {
            ViewBag.idUsuario = listaUsuarios();
            ViewBag.idEstadoPropiedad = listaEstadoPropiedad();
            ViewBag.idPlanCobro = listaPlanCobro();
            return View();
        }



        // GET: Propiedad/Edit/5
           [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Edit(int? id)
        {
            Propiedad oPropiedad = null;

            try
            {
                if (id == null)
                {
                    TempData["Message"] = "El ID no puede ser nulo";
                    return RedirectToAction("Index");
                }

                oPropiedad = _Service.GetPropiedadById(Convert.ToInt32(id));

                if (oPropiedad == null)
                {
                    TempData["Message"] = "No existe la propiedad solicitada";
                    TempData["Redirect"] = "Propiedad";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.idUsuario = listaUsuarios(oPropiedad.FK_Usuario);
                ViewBag.idEstadoPropiedad = listaEstadoPropiedad(oPropiedad.FK_EstadoPropiedad);
                ViewBag.idPlanCobro = listaPlanCobro(oPropiedad.FK_PlanCobro);
                return View(oPropiedad);

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

        // POST: Propiedad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Propiedad propiedad)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                       _Service.SaveOrUpdate(propiedad);

                    }
                    else
                    {
                        //Cargar la vista crear o actualizar

                        ViewBag.idUsuario = listaUsuarios(propiedad.FK_Usuario);
                        ViewBag.idEstadoPropiedad = listaEstadoPropiedad(propiedad.FK_EstadoPropiedad);
                        ViewBag.idPlanCobro = listaPlanCobro(propiedad.FK_PlanCobro);
                        //Lógica para cargar vista correspondiente

                        if (propiedad.Id == 0)
                        {
                            return View("Create", propiedad);
                        }
                        else
                        {
                            return View("Edit", propiedad);
                        }

                    }
                    return RedirectToAction("Index");
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



        public SelectList listaUsuarios(int? id = 0)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            IEnumerable<Usuario> lista = _ServiceUsuario.GetAll();
            return new SelectList(lista, "Id", "Nombre",id);
        }

        public SelectList listaEstadoPropiedad(int? id = 0)
        {
            IServiceEstados<EstadoPropiedad> _ServiceEstadoPropiedad = new ServiceEstadoPropiedad();
            IEnumerable<EstadoPropiedad> lista = _ServiceEstadoPropiedad.GetAll();
            return new SelectList(lista, "Id", "Nombre", id);
        }

        public SelectList listaPlanCobro(int? id = 0)
        {
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            IEnumerable<PlanCobro> lista = _ServicePlanCobro.GetAll();
            return new SelectList(lista, "Id", "Descripcion", id);
        }
    }
}
