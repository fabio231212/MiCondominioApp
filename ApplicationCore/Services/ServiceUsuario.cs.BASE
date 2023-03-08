using ApplicationCore.Utils;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public IEnumerable<Usuario> GetAll()
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            return repositoryUsuario.GetAll();
        }

        public Usuario GetUsuario(string email, string password)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            return repositoryUsuario.GetUsuario(email, password);
        }

        public Usuario GetUsuarioById(int cedula)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            return repositoryUsuario.GetUsuarioById(cedula);
        }

        public Usuario Login(string email, string clave)
        {
            
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            clave = Utilitarios.ConvertirSha256(clave);
            return  repositoryUsuario.Login(email, clave);

            
        }

        public Usuario Save(Usuario usuario)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            return repositoryUsuario.Save(usuario);
        }
    }
}
