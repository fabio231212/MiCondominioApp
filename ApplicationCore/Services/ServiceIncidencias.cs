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
        private IRepositoryIncidencias repository;
        public ServiceIncidencias()
        {
            repository = new RepositoryIncidencias();
        }

        public int ActualizarEstadoIncidencia(int id, int estado) => repository.ActualizarEstadoIncidencia(id, estado);
        

        public IEnumerable<Incidencias> GetAll() => repository.GetAll();

        public IEnumerable<Incidencias> GetByIdEstado(int idEstado) => repository.GetByIdEstado(idEstado);

        public IEnumerable<Incidencias> GetByIdUser(int idUser) => repository.GetByIdUser(idUser);

        public int RegistrarIncidencia(Incidencias oIncidencia) => repository.RegistrarIncidencia(oIncidencia);
    }
}
