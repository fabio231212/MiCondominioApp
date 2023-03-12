using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public  interface IRepositoryPropiedad
    {
        Propiedad GetPropiedadByNumProp(string numPropiedad);
        Propiedad GetPropiedadById(int id);
        void Save(Propiedad propiedad);
        void Update(Propiedad propiedad);
        IEnumerable<Propiedad> GetAll();
    }
}
