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
        public void Create(Informacion oInformacion)
        {
            IRepositoryInformacion repository = new RepositoryInformacion();
            repository.Create(oInformacion);
        }

        public IEnumerable<Informacion> GetAll()
        {
            IRepositoryInformacion repository = new RepositoryInformacion();
            return repository.GetAll();
        }

        public Informacion GetById(int id)
        {
            IRepositoryInformacion repository = new RepositoryInformacion();
            return repository.GetById(id);
        }
    }
}
