using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceIncidencias : IServiceIncidencias
    {

        public int ActualizarEstadoIncidencia(int id, int estado)
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.ActualizarEstadoIncidencia(id, estado);
        }

        public IEnumerable<Incidencias> GetAll()
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.GetAll();
        }

        public IEnumerable<Incidencias> GetByIdEstado(int idEstado)
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.GetByIdEstado(idEstado);
        }

        public IEnumerable<Incidencias> GetByIdUser(int idUser)
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.GetByIdUser(idUser);
        }

        public int RegistrarIncidencia(Incidencias oIncidencia)
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.RegistrarIncidencia(oIncidencia);
        }
    }
}
