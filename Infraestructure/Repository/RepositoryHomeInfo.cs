using Infraestructure.Models;
using Infraestructure.Models.DTO;
using Infraestructure.Repository.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
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

        public IEnumerable<DeudasVigentesDTO> GetCantFacPendientes(IEnumerable<Factura> facturas)
        {
            DateTimeFormatInfo monthInfo = new DateTimeFormatInfo();
            var cantFacPendientes = facturas.Where(f => f.FechaFacturacion.Value.Year == DateTime.Now.Year).Where(f => (bool)f.Activo)

                .GroupBy(f => new { f.FechaFacturacion.Value.Month })
            .Select(g => new DeudasVigentesDTO
            {
                Mes = new DateTime(g.Key.Month, g.Key.Month, 1).ToString("MMMM"),
                Cantidad = g.Count()

            })
            .OrderBy(r => DateTime.ParseExact(r.Mes, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month).ToList();
            return cantFacPendientes;
        }

        public IEnumerable<TotalesPorMesDTO> GetTotalFacturaPorMes(IEnumerable<Factura> facturas)
        {
            DateTimeFormatInfo monthInfo = new DateTimeFormatInfo();
            var totalesPorMes = facturas.Where(f => f.FechaFacturacion.Value.Year == DateTime.Now.Year)

                .GroupBy(f => new { f.FechaFacturacion.Value.Month })
            .Select(g => new TotalesPorMesDTO
            {
                Mes = new DateTime(g.Key.Month, g.Key.Month, 1).ToString("MMMM"),
                Total = (decimal)g.Sum(f => f.Total)
            })
            .OrderBy(r => DateTime.ParseExact(r.Mes, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month).ToList();







            return totalesPorMes;
            
        }
    }
}
