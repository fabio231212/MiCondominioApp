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
        public IEnumerable<Incidencias> GetAll()
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.GetAll();
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
