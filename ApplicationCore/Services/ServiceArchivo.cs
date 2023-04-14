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
        private IRepositoryArchivo repository;
        public ServiceArchivo()
        {
            repository = new RepositoryArchivo();
        }

        public Archivo Get(int id) => repository.Get(id);
        

        public IEnumerable<Archivo> GetAll() => repository.GetAll();

        public void Save(Archivo archivo) => repository.Save(archivo);
        
    }
}
