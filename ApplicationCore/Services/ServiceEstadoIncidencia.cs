using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoIncidencia : IServiceEstados<EstadoIncidencia>
    {
        private IRepositoryEstados<EstadoIncidencia> repository;
        public ServiceEstadoIncidencia()
        {
            repository = new RepositoryEstadoIncidencia();
        }

        public IEnumerable<EstadoIncidencia> GetAll() => repository.GetAll();
        
    }
}
