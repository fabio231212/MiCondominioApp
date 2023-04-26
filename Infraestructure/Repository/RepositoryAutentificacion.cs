using Infraestructure.Models;
using Infraestructure.Repository.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryAutentificacion : IRepositoryAutentificacion
    {
        public int CambiarClave(string email, string clave)
        {
            Usuario usuario = null;
            int resultado = 0;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                    if (usuario != null)
                    {
                        usuario.Clave = clave;

                        ctx.Configuration.LazyLoadingEnabled = false;
                        ctx.Usuario.Add(usuario);
                        ctx.Entry(usuario).State = EntityState.Modified;
                        resultado = ctx.SaveChanges();
                    }

                }
                return resultado;

            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Usuario Login(string email, string clave)
        {
            Usuario usuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Clave == clave);
                    usuario = ctx.Usuario.Include("Propiedad.Factura").FirstOrDefault(u => u.Email == email && u.Clave == clave);

                }
                return usuario;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public int RestablecerContrasennaByEmail(string email, string codigo)
        {
            Usuario usuario = null;
            int resultado = 0;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                    if(usuario!= null)
                    {
                        usuario.Clave = codigo;

                        ctx.Configuration.LazyLoadingEnabled = false;
                        ctx.Usuario.Add(usuario);
                        ctx.Entry(usuario).State = EntityState.Modified;
                        resultado = ctx.SaveChanges();
                    }

                }
                return resultado;
          
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public bool verificarCodRestablecer(string email,string codigo)
        {
            Usuario usuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Clave ==  codigo);

                    if (usuario != null)
                    {
                        return true;
                    }

                }
                return false;

            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}