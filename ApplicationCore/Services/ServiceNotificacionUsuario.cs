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
        private IRepositoryNotificacionUsuario repository;
        public ServiceNotificacionUsuario()
        {
            repository = new RepositoryNotificacionUsuario();
        }

        public IEnumerable<NotificacionUsuario> GetNotificacionByIdUser(int id) => repository.GetNotificacionByIdUser(id);
        

        public NotificacionUsuario MarcarLeido(int id) => repository.MarcarLeido(id);

        public void SaveNotificacionUsuario(NotificacionUsuario notificacionUsuario) => repository.SaveNotificacionUsuario(notificacionUsuario);
        
    }
}
