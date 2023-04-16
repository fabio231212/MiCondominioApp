using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceRol : IServiceRol
    {
        private IRepositoryRol repository;
        public ServiceRol()
        {
            repository = new RepositoryRol();
        }
        public IEnumerable<Rol> GetAll() => repository.GetAll();
        
    }
}
