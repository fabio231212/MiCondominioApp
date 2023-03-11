using Infraestructure.Models;
using Infraestructure.Models.DTO;
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
    public class RepositoryHomeInfo : IRepositoryHomeInfo
    {
        public int cantidadIncidencias()
        {

            int cantidad = 0;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    cantidad = ctx.Incidencias.Where(x=>x.FK_Estado != 3).Count();
                }
                return cantidad;
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

        public IEnumerable<TotalesPorMesDTO> GetTotalFacturaPorMes(IEnumerable<Factura> facturas)
        {
                var totalesPorMes = facturas.Where(f => f.FechaFacturacion.Value.Year == DateTime.Now.Year)
                    .GroupBy(f => new { Mes = f.FechaFacturacion.Value.Month})
                    .Select(g => new TotalesPorMesDTO
                    {
                        Mes = g.Key.Mes,
                        Total = (decimal)g.Sum(f => f.Total)
                    })
                    .OrderBy(g => g.Mes)
                    .ToList();

                return totalesPorMes;
            
        }
    }
}
