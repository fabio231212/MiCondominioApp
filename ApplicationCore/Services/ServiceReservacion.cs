using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReservacion : IServiceReservacion
    {
        IRepositoryReservacion repository;
        public ServiceReservacion()
        {
            repository = new RepositoryReservacion();
        }

        public void CambiarEstado(int id, string nota, int idEstado)
        {
            repository.CambiarEstado(id,nota,idEstado);
        }

        public IEnumerable<Reservacion> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<Reservacion> GetByEstado(int estado)
        {
            return repository.GetByEstado(estado);
        }

        public IEnumerable<Reservacion> GetAllByIdUsuario(int id)
        {
            return repository.GetAllByIdUsuario(id);
        }

        public int Save(Reservacion reservacion)
        {
            return repository.Save(reservacion);
        }

        public bool ValidarHorario(DateTime fechaEntrada, DateTime fechaSalida, int areaComunal)
        {
            return repository.ValidarHorario(fechaEntrada, fechaSalida,areaComunal);
        }

        public Reservacion GetByIdReservacion(int id)
        {
            return repository.GetByIdReservacion(id);
        }
    }
}
