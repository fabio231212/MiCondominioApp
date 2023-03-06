﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceIncidencias
    {
        IEnumerable<Incidencias> GetAll();
        IEnumerable<Incidencias> GetByIdUser(int idUser);
        int RegistrarIncidencia(Incidencias oIncidencia);
    }
}
