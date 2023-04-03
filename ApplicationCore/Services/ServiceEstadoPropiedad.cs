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
        public IEnumerable<EstadoPropiedad> GetAll()
        {
            IRepositoryEstados<EstadoPropiedad> repository = new RepositoryEstadoPropiedad();
            return repository.GetAll();
        }
    }
}
