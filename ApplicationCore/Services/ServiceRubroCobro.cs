using ApplicationCore.Utils;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceRubroCobro : IServiceRubroCobro
    {

        public void Delete(int cedula)
        {
            IRepositoryRubroCobro _RepositoryRubroCobro = new RepositoryRubroCobro();
            _RepositoryRubroCobro.Delete(cedula);
        }

        public IEnumerable<RubroCobro> GetAll()
        {
            IRepositoryRubroCobro _RepositoryRubroCobro = new RepositoryRubroCobro();
            return _RepositoryRubroCobro.GetAll();
        }

        public RubroCobro GetRubroById(int id)
        {
            IRepositoryRubroCobro _RepositoryRubroCobro = new RepositoryRubroCobro();
            return _RepositoryRubroCobro.GetRubroById(id);
        }

        public void SaveOrUpdate(RubroCobro rubro)
        {
            IRepositoryRubroCobro _RepositoryRubroCobro = new RepositoryRubroCobro();
            if (GetRubroById(rubro.Id) == null)
            {
                _RepositoryRubroCobro.Save(rubro);
            }
            else
            {
                _RepositoryRubroCobro.Update(rubro);
            }
        }
    }
}
