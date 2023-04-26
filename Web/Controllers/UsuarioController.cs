using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Infraestructure.Utils;
using Web.Permisos;
using System.Web.Services.Description;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IServiceUsuario _Service;

        public UsuarioController() => _Service = new ServiceUsuario();

        // GET: Usuario
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Index()
        {
            IEnumerable<Usuario> lista = null;
            try
            {
                lista = _Service.GetAll();
                ViewBag.Title = "Lista Usuarios";
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

        // GET: Usuario/Details/5
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Details(int id)
        {
            Usuario oUsuario= null;
            try
            {
                oUsuario = _Service.GetUsuarioById(id);
                ViewBag.IdActivo = listaActivo(oUsuario.Activo);
                return View(oUsuario);

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

        // GET: Usuario/Create
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Create()
        {

            ViewBag.IdRol = listaRoles();
            ViewBag.IdActivo = listaActivo();
            return View();
        }


        // GET: Usuario/Edit/5
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Edit(int? cedula)
        {
            Usuario oUsuario = null;

            try
            {
                if (cedula == null)
                {
                    TempData["Message"] = "El ID no puede ser nulo";
                    return RedirectToAction("Index");
                }

                oUsuario = _Service.GetUsuarioById(Convert.ToInt32(cedula));

                if (oUsuario == null)
                {
                    TempData["Message"] = "No existe el usuario Solicitado";
                    TempData["Redirect"] = "Usuario";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.IdRol = listaRoles(oUsuario.FK_Rol);
                ViewBag.IdActivo = listaActivo(oUsuario.Activo);
                return View(oUsuario);

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

         // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Save(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Service.SaveOrUpdate(usuario);

                }
                else
                {
                    ViewBag.IdRol = listaRoles(usuario.FK_Rol);
                    ViewBag.IdActivo = listaActivo(usuario.Activo);
                    if (usuario.Id == 0)
                    {
                        return View("Create", usuario);
                    }
                    else
                    {
                        return View("Edit", usuario);
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

        [CustomAuthorize((int)Roles.Admin)]
        public ActionResult Delete(int idUsuario)
        {
            try
            {
                _Service.Delete(idUsuario);              
                return RedirectToAction("Index", "Usuario");
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

        private SelectList listaRoles(int? idRol = 0)
        {
            IServiceRol _ServiceRol = new ServiceRol();
            IEnumerable<Rol> lista = _ServiceRol.GetAll();
            return new SelectList(lista, "Id", "Nombre", idRol);
        }

        private SelectList listaActivo(bool? activo = true)
        {
            var lista = new List<SelectListItem>
                {
                      new SelectListItem { Value = "true", Text = "Activo" },
                      new SelectListItem { Value = "false", Text = "Inactivo" }
                };
            return new SelectList(lista, "Value", "Text", activo);
        }


    }
}
