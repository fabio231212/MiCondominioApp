using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceReservacion
    {
        IEnumerable<Reservacion> GetByIdUsuario(int id);
        IEnumerable<Reservacion> GetAll();

        int Save(Reservacion reservacion);

        IEnumerable<Reservacion> GetByEstado(int estado);

        bool ValidarHorario(DateTime fechaEntrada, DateTime fechaSalida, int areaComunal);
    }
}
