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

        public IEnumerable<Reservacion> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<Reservacion> GetByEstado(int estado)
        {
            return repository.GetByEstado(estado);
        }

        public IEnumerable<Reservacion> GetByIdUsuario(int id)
        {
            return repository.GetByIdUsuario(id);
        }

        public int Save(Reservacion reservacion)
        {
            return repository.Save(reservacion);
        }

        public bool ValidarHorario(DateTime fechaEntrada, DateTime fechaSalida, int areaComunal)
        {
            return repository.ValidarHorario(fechaEntrada, fechaSalida,areaComunal);
        }
    }
}
