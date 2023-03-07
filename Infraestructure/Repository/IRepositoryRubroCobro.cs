using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IRepositoryRubroCobro
    {
        RubroCobro GetRubroById(int id);
        void Save(RubroCobro rubro);
        void Delete(int id);
        void Update(RubroCobro rubro);
        IEnumerable<RubroCobro> GetAll();
    }
}
