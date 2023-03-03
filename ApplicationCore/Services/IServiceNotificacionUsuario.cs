using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceNotificacionUsuario
    {
        IEnumerable<NotificacionUsuario> GetNotificacionByIdUser(int id);
        NotificacionUsuario MarcarLeido(int id);
    }
}
