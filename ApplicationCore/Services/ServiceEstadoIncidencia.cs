using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoIncidencia : IServiceEstadoIncidencia
    {
        public IEnumerable<EstadoIncidencia> GetAll()
        {
            IRepositoryEstadoIncidencia repository = new RepositoryEstadoIncidencia();
            return repository.GetAll();
        }
    }
}
