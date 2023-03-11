using Infraestructure.Models;
using Infraestructure.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryHomeInfo
    {
         IEnumerable<TotalesPorMesDTO> GetTotalFacturaPorMes(IEnumerable<Factura> facturas);
        int cantidadIncidencias();
    }
}
