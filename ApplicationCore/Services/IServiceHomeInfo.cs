using Infraestructure.Models.DTO;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceHomeInfo
    {
        IEnumerable<TotalesPorMesDTO> GetTotalFacturaPorMes(IEnumerable<Factura> facturas);
        int cantidadIncidencias();
    }
}
