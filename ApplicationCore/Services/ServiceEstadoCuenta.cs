using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{

    public class ServiceEstadoCuenta : IServiceEstadoCuenta
    {
        private IRepositoryEstadoCuenta repository;
        public ServiceEstadoCuenta()
        {
            repository = new RepositoryEstadoCuenta();
        }

        public IEnumerable<Factura> GetAll() => repository.GetAll();
        

        public IEnumerable<Factura> GetByIdProp(int id)=> repository.GetByIdProp(id);
        public IEnumerable<Factura> GetEstadoCuentaByFilter(bool active, int id)=> repository.GetEstadoCuentaByFilter(active, id);

        public Factura GetDetalleEstadoCuenta(int idEstadoCuenta) => repository.GetDetalleEstadoCuenta(idEstadoCuenta);

        public IEnumerable<Factura> GetEstadoCuentaPendiente() => repository.GetEstadoCuentaPendiente();

        public void Create(Factura factura) =>repository.Create(factura);
        

        public IEnumerable<Factura> GetFacturasByFecha() => repository.GetFacturasByFecha();
    }
}
