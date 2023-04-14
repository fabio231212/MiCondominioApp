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
        private IRepositoryEstados<EstadoReservacion> repository;
        public ServiceEstadoReservacion()
        {
            repository = new RepositoryEstadoReservacion();
        }

        public IEnumerable<EstadoReservacion> GetAll() => repository.GetAll();
    }
}
