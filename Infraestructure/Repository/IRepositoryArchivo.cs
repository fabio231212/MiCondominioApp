using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryArchivo
    {
        void Save(Archivo archivo);
        IEnumerable<Archivo> GetAll();

        Archivo Get(int id);
    }
}
