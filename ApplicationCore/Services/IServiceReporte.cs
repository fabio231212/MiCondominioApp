using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceReporte
    {
        dynamic reporteDeudas(DateTime? fechaInicio, DateTime? fechaFin, string numPropiedad);
    }
}
