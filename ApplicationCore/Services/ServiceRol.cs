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
        public IEnumerable<Rol> GetAll()
        {
            IRepositoryRol _RepositoryRol = new RepositoryRol();
            return _RepositoryRol.GetAll();
        }
    }
}
