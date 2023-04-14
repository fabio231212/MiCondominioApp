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
        private IRepositoryHomeInfo repository;
        public ServiceHomeInfo()
        {
            repository = new RepositoryHomeInfo();
        }

        public int cantidadIncidencias() => repository.cantidadIncidencias();
        

        public IEnumerable<DeudasVigentesDTO> GetCantFacPendientes(IEnumerable<Factura> facturas) => repository.GetCantFacPendientes(facturas);
        

        public IEnumerable<TotalesPorMesDTO> GetTotalFacturaPorMes(IEnumerable<Factura> facturas) => repository.GetTotalFacturaPorMes(facturas);
    }
}
