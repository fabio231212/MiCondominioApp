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
        private IRepositoryRubroCobro repository;
        public ServiceRubroCobro()
        {
            repository = new RepositoryRubroCobro();
        }
        public void Delete(int cedula) => repository.Delete(cedula);
        

        public IEnumerable<RubroCobro> GetAll() => repository.GetAll();

        public RubroCobro GetRubroById(int id) => repository.GetRubroById(id);

        public void SaveOrUpdate(RubroCobro rubro)
        { 
            if (GetRubroById(rubro.Id) == null)
            {
                repository.Save(rubro);
            }
            else
            {
                repository.Update(rubro);
            }
        }
    }
}
