using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PRUEBAController : Controller
    {
        [HttpGet]
        public JsonResult GetPlanById(int id)
        {
            IServicePlanCobro _ServicePlan = new ServicePlanCobro();
            PlanCobro plan = _ServicePlan.GetById(id);
            return Json(new { data = plan }, JsonRequestBehavior.AllowGet);

        }
    }
}