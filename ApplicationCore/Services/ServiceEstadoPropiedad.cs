﻿using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoPropiedad : IServiceEstadoPropiedad
    {
        public IEnumerable<EstadoPropiedad> GetAll()
        {
            IRepositoryEstadoPropiedad repository = new RepositoryEstadoPropiedad();
            return repository.GetAll();
        }
    }
}
