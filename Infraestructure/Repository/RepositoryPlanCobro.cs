using ApplicationCore.Services;
using Infraestructure.Models;
using Infraestructure.Repository.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryPlanCobro : IRepositoryPlanCobro
    {
        public void Delete(int cedula)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanCobro> GetAll()
        {
            try
            {
                IEnumerable<PlanCobro> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.PlanCobro.ToList();
                }

                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public PlanCobro GetById(int id)
        {
            try
            {
                PlanCobro oPlan= null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oPlan = ctx.PlanCobro.Include("RubroCobro").Where(p => p.Id == id).FirstOrDefault<PlanCobro>();

                }
                return oPlan;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public void SaveOrUpdate(PlanCobro plan, String[] rubrosSeleccionados)
        {

            PlanCobro oPlan= null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oPlan = GetById((int)plan.Id);
                    IRepositoryRubroCobro _RepositoryRubro = new RepositoryRubroCobro();


                    if (oPlan == null)
                    {

                        if (rubrosSeleccionados != null)
                        {

                            plan.RubroCobro = new List<RubroCobro>();
                            foreach (var rubro in rubrosSeleccionados)
                            {
                                var rubroToAdd = _RepositoryRubro.GetRubroById(int.Parse(rubro));
                                ctx.RubroCobro.Attach(rubroToAdd);
                                plan.RubroCobro.Add(rubroToAdd);


                            }
                        }


                        ctx.PlanCobro.Add(plan);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.PlanCobro.Add(plan);
                        ctx.Entry(plan).State = EntityState.Modified;
                        ctx.SaveChanges();

                        var rubrosSeleccionadosID = new HashSet<string>(rubrosSeleccionados);
                        if (rubrosSeleccionados != null)
                        {
                            ctx.Entry(plan).Collection(p => p.RubroCobro).Load();
                            var nuevoRubro = ctx.RubroCobro
                             .Where(x => rubrosSeleccionadosID.Contains(x.Id.ToString())).ToList();
                            plan.RubroCobro = nuevoRubro;

                            ctx.Entry(plan).State = EntityState.Modified;
                            ctx.SaveChanges();
                        }
                    }

                }
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

    }
}
