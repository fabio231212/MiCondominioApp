﻿using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoIncidencia : IServiceEstados<EstadoIncidencia>
    {
        public IEnumerable<EstadoIncidencia> GetAll()
        {
            IRepositoryEstados<EstadoIncidencia> repository = new RepositoryEstadoIncidencia();
            return repository.GetAll();
        }
    }
}
