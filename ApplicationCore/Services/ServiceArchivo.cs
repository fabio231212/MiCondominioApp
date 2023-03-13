using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceArchivo : IServiceArchivo
    {
        public Archivo Get(int id)
        {
            IRepositoryArchivo repository = new RepositoryArchivo();
            return repository.Get(id);
        }

        public IEnumerable<Archivo> GetAll()
        {
            IRepositoryArchivo repository = new RepositoryArchivo();
            return repository.GetAll();
        }

        public void Save(Archivo archivo)
        {
            IRepositoryArchivo repository = new RepositoryArchivo();
            repository.Save(archivo);
        }
    }
}
