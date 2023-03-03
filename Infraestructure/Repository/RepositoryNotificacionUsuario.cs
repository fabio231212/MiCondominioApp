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
    public class RepositoryNotificacionUsuario : IRepositoryNotificacionUsuario
    {
        public IEnumerable<NotificacionUsuario> GetNotificacionByIdUser(int id)
        {
            
                IEnumerable<NotificacionUsuario> lista = null;
                try
                {


                    using (MyContext ctx = new MyContext())
                    {
                        ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.NotificacionUsuario.Include("Notificacion").Where(x => (bool)!x.Leida).ToList();
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
    }
}
