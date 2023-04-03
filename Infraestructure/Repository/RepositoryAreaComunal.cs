using Infraestructure.Models;
using Infraestructure.Repository.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryAreaComunal : IRepositoryAreaComunal
    {
        public IEnumerable<AreaComunal> GetAll()
        {
            IEnumerable<AreaComunal> lista = null;
			try
			{
				using(MyContext ctx = new MyContext())
				{
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.AreaComunal.ToList();
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

        public AreaComunal GetAreaComunalById(int id)
        {
            AreaComunal areaComunal = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    areaComunal = ctx.AreaComunal.Where(a => a.Id == id).FirstOrDefault();
                }
                return areaComunal;
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
