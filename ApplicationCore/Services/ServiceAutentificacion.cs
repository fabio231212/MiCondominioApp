using ApplicationCore.Utils;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceAutentificacion : IServiceAutentificacion
    {
        public Usuario Login(string email, string clave)
        {
            IRepositoryAutentificacion repository = new RepositoryAutentificacion();
            clave = Utilitarios.ConvertirSha256(clave);
            return repository.Login(email, clave);
        }
    }
}
