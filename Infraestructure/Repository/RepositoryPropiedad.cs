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
    public class RepositoryPropiedad : IRepositoryPropiedad
    {
        public IEnumerable<Propiedad> GetAll()
        {
            IEnumerable<Propiedad> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Propiedad.Include("Usuario").ToList();

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

        public Propiedad GetPropiedadByNumProp(string id)
        {
            try
            {
                Propiedad oPropiedad = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oPropiedad = ctx.Propiedad.Include("EstadoPropiedad").Include("Usuario").
                    Where(p => p.NumPropiedad == id).
                    FirstOrDefault<Propiedad>();
                  
                }
                return oPropiedad;
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

        public Propiedad Save(Propiedad propiedad)
        {
            int retorno = 0;
            Propiedad oPropiedad = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //Registradas: 1,2,3
                //Actualizar: 1,3,4

                //Insertar Libro
                ctx.Propiedad.Add(propiedad);
                //SaveChanges
                //guarda todos los cambios realizados en el contexto de la base de datos.
                retorno = ctx.SaveChanges();

            }
            

            if (retorno >= 0)
                oPropiedad = GetPropiedadByNumProp(propiedad.NumPropiedad);

            return oPropiedad;
        }
    }
}
