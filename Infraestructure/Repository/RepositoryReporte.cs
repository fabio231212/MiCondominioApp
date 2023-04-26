using Infraestructure.Models.DTO;
using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Repository.Models;

namespace Infraestructure.Repository
{
    public class RepositoryReporte : IRepositoryReporte
    {

        public IEnumerable<Factura> reporteDeudas(DateTime? fechaInicio, DateTime? fechaFin, string numPropiedad)
        {
            IEnumerable<Factura> listaFact = null;
            MyContext ctx = new MyContext();
            try
            {
                if (fechaInicio != null && fechaFin != null && String.IsNullOrEmpty(numPropiedad))
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    listaFact = ctx.Factura.Include("PlanCobro").Include("PlanCobro.RubroCobro").Include("Propiedad").ToList().Where(f => f.Activo == true && f.FechaFacturacion >= fechaInicio && f.FechaFacturacion <= fechaFin);

                    return listaFact;

                }
                else
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    listaFact = ctx.Factura.Include("PlanCobro").Include("PlanCobro.RubroCobro").Include("Propiedad").ToList().Where(f => f.Activo == true && f.FechaFacturacion >= fechaInicio && f.FechaFacturacion <= fechaFin && f.Propiedad.NumPropiedad == numPropiedad);

                    return listaFact;
                }


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
