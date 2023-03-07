﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryPlanCobro
    {
        IEnumerable<PlanCobro> GetAll();
        PlanCobro GetById(int id);
        void SaveOrUpdate(PlanCobro plan, String[] rubrosSeleccionados);
        void Delete(int cedula);
    }
}
