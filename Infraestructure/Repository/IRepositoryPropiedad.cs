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
        Propiedad Save(Propiedad propiedad);
        IEnumerable<Propiedad> GetAll();
    }
}
