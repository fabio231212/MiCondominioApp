using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceInformacion : IServiceInformacion
    {
        public IEnumerable<Informacion> GetAll()
        {
            IRepositoryInformacion repository = new RepositoryInformacion();
            return repository.GetAll();
        }
    }
}
