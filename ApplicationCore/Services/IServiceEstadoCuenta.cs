using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceEstadoCuenta
    {
        IEnumerable<Factura> GetAll();
        IEnumerable<Factura> GetByIdProp(int id);
        IEnumerable<Factura> GetEstadoCuentaByFilter(bool active, int id);

        Factura GetDetalleEstadoCuenta(int idEstadoCuenta);
        void Create(Factura factura);
        IEnumerable<Factura> GetEstadoCuentaPendiente();
        IEnumerable<Factura> GetFacturasByFecha();
        Factura GetOldestFactura(int idUsuario);
        int UpdateNumTarjeta(string numTajeta, int idFactura);

        int PagarFactura(int idFactura);
    }
}
