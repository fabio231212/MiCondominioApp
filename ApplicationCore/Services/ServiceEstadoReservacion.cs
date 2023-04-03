using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoReservacion : IServiceEstados<EstadoReservacion>
    {
        public IEnumerable<EstadoReservacion> GetAll()
        {
            IRepositoryEstados<EstadoReservacion> repository = new RepositoryEstadoReservacion();
            return repository.GetAll();
        }
    }
}
