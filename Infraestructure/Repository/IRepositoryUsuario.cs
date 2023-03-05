﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryUsuario
    {
        Usuario GetUsuarioById(int cedula);

        Usuario GetUsuario(string email, string password);
        IEnumerable<Usuario> GetAll();

    }
}
