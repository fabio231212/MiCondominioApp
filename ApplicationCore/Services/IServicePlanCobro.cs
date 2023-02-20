using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicePlanCobro
    {
        IEnumerable<PlanCobro> GetAll();
        PlanCobro GetById(int id);
    }
}
