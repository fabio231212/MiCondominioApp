using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface I_IncidenciaRepository
    {

        IEnumerable<Incidencias> getAll();
        IEnumerable<Incidencias> getByIdUser(int idUser);
    }
}
