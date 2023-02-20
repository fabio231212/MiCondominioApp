using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePlanCobro : IServicePlanCobro
    {
        public IEnumerable<PlanCobro> GetAll()
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetAll();
        }

        public PlanCobro GetById(int id)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetById(id);
        }
    }
}
