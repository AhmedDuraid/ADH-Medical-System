using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Plan")]
    public class PlanController : ApiController
    {
        // GET: api/Plan
        public List<PlanModel> Get()
        {
            PlanData planData = new PlanData();

            var Plan = planData.GetPlans();

            return Plan;
        }

        // GET: api/Plan/5
        public List<PlanModel> Get(int id)
        {
            PlanData planData = new PlanData();

            var Plan = planData.GetPlanById(id);

            return Plan;
        }

        // GET: api/Plan/?PlanType={type}
        public List<PlanModel> Get(string planType)
        {
            PlanData planData = new PlanData();

            var Plans = planData.GetPlansByType(planType);

            return Plans;
        }
        // POST: api/Plan
        public void Post([FromBody] PlanModel plan)
        {
            PlanData planData = new PlanData();

            planData.AddPlan(plan);

        }

    }
}
