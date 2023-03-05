using Infraestructure.Models;
using Infraestructure.Repository.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public IEnumerable<Usuario> GetAll()
        {
            IEnumerable<Usuario> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.Usuario.Include("Rol").ToList();

                    //lista = ctx.Libro.Include(x=>x.Autor).ToList();

                }
                return lista;
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

        public Usuario GetUsuario(string email, string password)
        {
            Usuario oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = ctx.Usuario.
                     Where(p => p.Email.Equals(email) && p.Clave == password).
                    FirstOrDefault<Usuario>();
                }
                if (oUsuario != null)
                    oUsuario = GetUsuarioById(oUsuario.Cedula);
                return oUsuario;
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

        public Usuario GetUsuarioById(int cedula)
        {
            Usuario usuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.Usuario.
                     Include("Rol").
                    Where(p => p.Id == cedula).
                    FirstOrDefault<Usuario>();
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


        public Usuario Save(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
