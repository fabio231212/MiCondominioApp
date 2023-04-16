using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoPropiedad : IServiceEstados<EstadoPropiedad>
    {
        private IRepositoryEstados<EstadoPropiedad> repository;
        public ServiceEstadoPropiedad()
        {
            repository = new RepositoryEstadoPropiedad();
       }

        public IEnumerable<EstadoPropiedad> GetAll() => repository.GetAll();
        
    }
}
