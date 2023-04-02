using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryNotificacionUsuario
    {
        IEnumerable<NotificacionUsuario> GetNotificacionByIdUser(int id);
        NotificacionUsuario MarcarLeido(int id);
        void SaveNotificacionUsuario(NotificacionUsuario notificacionUsuario);
    }

}
