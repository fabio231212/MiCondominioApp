using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryAreaComunal
    {
        IEnumerable<AreaComunal> GetAll();
        AreaComunal GetAreaComunalById(int id);
    }
}
