using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePropiedad : IServicePropiedad
    {
        private IRepositoryPropiedad repository;
        public ServicePropiedad()
        {
            repository = new RepositoryPropiedad();
        }
        public IEnumerable<Propiedad> GetAll() => repository.GetAll();
        

        public Propiedad GetPropiedadById(int id) => repository.GetPropiedadById(id);
        

        public Propiedad GetPropiedadByNumProp(string numPropiedad) => repository.GetPropiedadByNumProp(numPropiedad);
        

        public void  SaveOrUpdate(Propiedad propiedad)
        {
            if (repository.GetPropiedadById(propiedad.Id) == null)
            {
                repository.Save(propiedad);
            }
            else
            {
                repository.Update(propiedad);
            }

        }
    }
}
