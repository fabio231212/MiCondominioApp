using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceArchivo
    {
        void Save(Archivo archivo);
        IEnumerable<Archivo> GetAll();

        Archivo Get(int id);
    }
}
