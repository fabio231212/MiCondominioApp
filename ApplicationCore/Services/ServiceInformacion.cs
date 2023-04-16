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
        private IRepositoryInformacion repository;
        public ServiceInformacion()
        {
            repository = new RepositoryInformacion();
        }
        public void Create(Informacion oInformacion) => repository.Create(oInformacion);
        

        public IEnumerable<Informacion> GetAll() => repository.GetAll();
        

        public Informacion GetById(int id) => repository.GetById(id);
    }
}
