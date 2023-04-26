using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceAutentificacion
    {
        Usuario Login(string email, string clave);
        int RestablecerContrasennaByEmail(string email);

        int CambiarClave(string email, string clave);

        bool verificarCodRestablecer(string email,string codigo);




    }
}
