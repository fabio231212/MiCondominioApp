using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryUsuario
    {
        Usuario GetUsuarioById(int cedula);
        void Save(Usuario usuario);
        void Delete(int cedula);
        void Update(Usuario usuario);
        Usuario GetUsuario(string email, string password);
        IEnumerable<Usuario> GetAll();

    }
}
