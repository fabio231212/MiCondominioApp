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
        public IEnumerable<Propiedad> GetAll()
        {
            IRepositoryPropiedad repository = new RepositoryPropiedad();
            return repository.GetAll();
        }

        public Propiedad GetPropiedadByNumProp(string numPropiedad)
        {
            IRepositoryPropiedad repository = new RepositoryPropiedad();
            return repository.GetPropiedadByNumProp(numPropiedad);
        }

        public Propiedad Save(Propiedad propiedad)
        {
            throw new NotImplementedException();
        }
    }
}
