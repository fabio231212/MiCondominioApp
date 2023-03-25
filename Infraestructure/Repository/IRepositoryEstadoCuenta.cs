using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryEstadoCuenta
    {
        IEnumerable<Factura> GetAll();
        IEnumerable<Factura> GetByIdProp(int id);
        IEnumerable<Factura> GetEstadoCuentaByFilter(bool active, int id);
        Factura GetDetalleEstadoCuenta(int idEstadoCuenta);
        IEnumerable<Factura> GetEstadoCuentaPendiente();
        void Create(Factura factura);
    }
}
