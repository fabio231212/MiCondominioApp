using ApplicationCore.Utils;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public void Delete(int cedula)
        {
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            repositoryUsuario.Delete(cedula);
        }

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

        public void SaveOrUpdate(Usuario usuario)
        {
            usuario.Clave = Utilitarios.ConvertirSha256(usuario.Clave);
            IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            if (GetUsuarioById(usuario.Cedula) == null)
            {
                repositoryUsuario.Save(usuario);
            }
            else
            {
                repositoryUsuario.Update(usuario);
            }
        }


    }
}