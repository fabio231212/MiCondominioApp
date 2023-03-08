using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryIncidencias
    {
        IEnumerable<Incidencias> GetByIdEstado(int idEstado);

        IEnumerable<Incidencias> GetAll();
        IEnumerable<Incidencias> GetByIdUser(int idUser);
        int RegistrarIncidencia(Incidencias oIncidencia);

        int ActualizarEstadoIncidencia(int id, int estado);
    }
}
