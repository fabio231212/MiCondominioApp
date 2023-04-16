using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceAreaComunal : IServiceAreaComunal
    {

        private IRepositoryAreaComunal repository;
        public ServiceAreaComunal()
        {
            repository = new RepositoryAreaComunal();
        }
            
        
        public IEnumerable<AreaComunal> GetAll() => repository.GetAll();
        

        public AreaComunal GetAreaComunalById(int id) => repository.GetAreaComunalById(id);
        
    }
}
