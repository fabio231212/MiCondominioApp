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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            IEnumerable<Usuario> lista = null;
            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();
                lista = _ServiceUsuario.GetAll();
                ViewBag.Title = "Lista Usuarios";
                return View(lista);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {

            ViewBag.IdRol = listaRoles();
            ViewBag.Activo = listaActivo();
            return View();
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? cedula)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            Usuario oUsuario = null;

            try
            {
                if (cedula == null)
                {
                    TempData["Message"] = "El ID no puede ser nulo";
                    return RedirectToAction("Index");
                }

                oUsuario = _ServiceUsuario.GetUsuarioById(Convert.ToInt32(cedula));

                if (oUsuario == null)
                {
                    TempData["Message"] = "No existe el usuario Solicitado";
                    TempData["Redirect"] = "Usuario";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.IdRol = listaRoles(oUsuario.FK_Rol);
                ViewBag.Activo = listaActivo(oUsuario.Activo);
                return View(oUsuario);

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

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Save(Usuario usuario)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            try
            {
                if (ModelState.IsValid)
                {
                    _ServiceUsuario.SaveOrUpdate(usuario);

                }
                else
                {
                    ViewBag.IdRol = listaRoles(usuario.FK_Rol);
                    ViewBag.Activo = listaActivo(usuario.Activo);
                    if (Request.Path == "/Usuario/Create")
                    {
                        return View("Create", usuario);
                    }
                    else if (Request.Path == "/Usuario/Edit")
                    {
                        return View("Edit", usuario.Cedula);
                    }
                    else
                    {
                        return RedirectToAction("Default", "Error");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            int facturasPendientes = 0;

            try
            {
                IServiceUsuario serviceUsuario = new ServiceUsuario();
                if (ModelState.IsValid)
                {
                    oUsuario = serviceUsuario.Login(oUsuario.Email, oUsuario.Clave);
                }
                else
                {
                    return View("Login", oUsuario);
                }

                if (oUsuario != null)
                {

                    foreach (Propiedad itemProp in oUsuario.Propiedad)
                    {
                        foreach (Factura itemFac in itemProp.Factura)
                        {
                            if ((bool)itemFac.Activo)
                            {
                                facturasPendientes++;
                            }
                        }
                    }

                    Session["facturasPendientes"] = facturasPendientes;
                    Session["Usuario"] = oUsuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Mensaje"] = "Usuario no encontrado";
                    return View();
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                ViewData["Mensaje"] = "Error al procesar los datos!" + ex.Message;
                return View();
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
