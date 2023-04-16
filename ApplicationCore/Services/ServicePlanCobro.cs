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

        private IRepositoryPlanCobro repository;
        public ServicePlanCobro() => repository = new RepositoryPlanCobro();

        public void Delete(int id) => repository.Delete(id);
        

        public IEnumerable<PlanCobro> GetAll() => repository.GetAll();
        

        public PlanCobro GetById(int id) => repository.GetById(id);
        

        public void SaveOrUpdate(PlanCobro plan, String[] rubrosSeleccionados) => repository.SaveOrUpdate(plan, rubrosSeleccionados);
    }
}
