﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicePropiedad
    {
        Propiedad GetPropiedadByNumProp(string numPropiedad);
        Propiedad Save(Propiedad propiedad);
        IEnumerable<Propiedad> GetAll();
    }
}
