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
using System.Web.UI.WebControls;

namespace Web.Controllers
{
    [Authorize]
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
                ViewBag.Notification = "Hola soy Fabio";
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
            ViewBag.idUsuario = listaUsuarios();
            ViewBag.idEstadoPropiedad = listaEstadoPropiedad();
            ViewBag.idPlanCobro = listaPlanCobro();
            return View();
        }

        // POST: Propiedad/Create
        [HttpPost]
        public ActionResult Create(Propiedad oPropiedad)
        {
            IServicePropiedad _ServicePropiedad = new ServicePropiedad();
            try
            {
                if (ModelState.IsValid)
                {
                    Propiedad oPropiedadI = _ServicePropiedad.Save(oPropiedad);

                }
                else
                {
                    //Cargar la vista crear o actualizar

                    ViewBag.idUsuario = listaUsuarios((int)oPropiedad.FK_Usuario);
                    ViewBag.idEstadoPropiedad = listaEstadoPropiedad((int)oPropiedad.FK_EstadoPropiedad);
                    ViewBag.idPlanCobro = listaPlanCobro((int)oPropiedad.FK_PlanCobro);
                    //Lógica para cargar vista correspondiente
                    return View("Create", oPropiedad);

                }
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                // Salvar el error en un archivo 

                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
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
        public SelectList listaUsuarios(int id = 0)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            IEnumerable<Usuario> lista = _ServiceUsuario.GetAll();
            return new SelectList(lista, "Id", "Nombre",id);
        }

        public SelectList listaEstadoPropiedad(int id = 0)
        {
            IServiceEstadoPropiedad _ServiceEstadoPropiedad = new ServiceEstadoPropiedad();
            IEnumerable<EstadoPropiedad> lista = _ServiceEstadoPropiedad.GetAll();
            return new SelectList(lista, "Id", "Nombre", id);
        }

        public SelectList listaPlanCobro(int id = 0)
        {
            IServicePlanCobro _ServicePlanCobro = new ServicePlanCobro();
            IEnumerable<PlanCobro> lista = _ServicePlanCobro.GetAll();
            return new SelectList(lista, "Id", "Descripcion", id);
        }
    }
}
