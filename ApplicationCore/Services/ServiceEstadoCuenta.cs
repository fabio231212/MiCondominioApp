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
        public IEnumerable<Factura> GetAll()
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetAll();
        }

        public IEnumerable<Factura> GetByIdProp(int id)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetByIdProp(id);
        }
        public IEnumerable<Factura> GetEstadoCuentaByFilter(bool active, int id)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaByFilter(active, id);
        }

        public Factura GetDetalleEstadoCuenta(int idEstadoCuenta)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetDetalleEstadoCuenta(idEstadoCuenta);
        }

        public IEnumerable<Factura> GetEstadoCuentaPendiente()
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaPendiente();
        }

        public void Create(Factura factura)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
             repository.Create(factura);
        }

        public IEnumerable<Factura> GetFacturasByFecha()
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetFacturasByFecha();
        }
    }
}
