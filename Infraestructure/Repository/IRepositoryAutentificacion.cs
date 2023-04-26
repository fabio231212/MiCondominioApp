using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryAutentificacion
    {
        Usuario Login(string email, string clave);

        int RestablecerContrasennaByEmail(string email, string codigo);

        bool verificarCodRestablecer(string email,string codigo);

        int CambiarClave(string email, string clave);
    }


}