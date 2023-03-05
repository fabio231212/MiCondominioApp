using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceNotificacionUsuario : IServiceNotificacionUsuario
    {
        public IEnumerable<NotificacionUsuario> GetNotificacionByIdUser(int id)
        {
            IRepositoryNotificacionUsuario repository = new RepositoryNotificacionUsuario();
            return repository.GetNotificacionByIdUser(id);
        }

        public NotificacionUsuario MarcarLeido(int id)
        {
            IRepositoryNotificacionUsuario repository = new RepositoryNotificacionUsuario();
            return repository.MarcarLeido(id);
        }
    }
}
