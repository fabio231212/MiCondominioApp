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
        public void Delete(int id)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            repository.Delete(id);
        }

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
        public void SaveOrUpdate(PlanCobro plan)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            if (GetById(plan.Id) == null)
            {
                repository.Save(plan);
            }
            else
            {
                repository.Update(plan);
            }
        }
    }
}
