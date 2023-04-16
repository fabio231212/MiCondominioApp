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
        private IRepositoryUsuario repository;
        public ServiceUsuario()
        {
            repository = new RepositoryUsuario();
        }

        public void Delete(int cedula) => repository.Delete(cedula);
        

        public IEnumerable<Usuario> GetAll() => repository.GetAll();
        

        public Usuario GetUsuario(string email, string password) => repository.GetUsuario(email, password);
        

        public Usuario GetUsuarioById(int cedula) => repository.GetUsuarioById(cedula);

        public void SaveOrUpdate(Usuario usuario)
        {
            usuario.Clave = Utilitarios.ConvertirSha256(usuario.Clave);
            if (GetUsuarioById(usuario.Cedula) == null)
            {
                repository.Save(usuario);
            }
            else
            {
                repository.Update(usuario);
            }
        }


    }
}