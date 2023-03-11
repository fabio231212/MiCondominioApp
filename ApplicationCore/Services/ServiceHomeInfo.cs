using Infraestructure.Models;
using Infraestructure.Models.DTO;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceHomeInfo : IServiceHomeInfo
    {
        public int cantidadIncidencias()
        {
            IRepositoryHomeInfo repository = new RepositoryHomeInfo();
            return repository.cantidadIncidencias();
        }

        public IEnumerable<TotalesPorMesDTO> GetTotalFacturaPorMes(IEnumerable<Factura> facturas)
        {
            IRepositoryHomeInfo repository = new RepositoryHomeInfo();
            return  repository.GetTotalFacturaPorMes(facturas);
        }
    }
}
