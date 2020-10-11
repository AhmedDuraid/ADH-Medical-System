using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PlanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Plan
        [HttpGet]
        public List<PlanModel> Get()
        {
            PlanData planData = new PlanData(_configuration);

            var Plan = planData.GetPlans();

            return Plan;
        }

        // GET: api/Plan/5
        [HttpGet]
        public List<PlanModel> Get(int id)
        {
            PlanData planData = new PlanData(_configuration);

            var Plan = planData.GetPlanById(id);

            return Plan;
        }

        // GET: api/Plan/?PlanType={type}
        [HttpGet("{id}")]
        // checks ????
        public List<PlanModel> Get(string planType)
        {
            PlanData planData = new PlanData(_configuration);

            var Plans = planData.GetPlansByType(planType);

            return Plans;
        }

        // POST: api/Plan
        [HttpPost]
        public void Post([FromBody] PlanModel plan)
        {
            PlanData planData = new PlanData(_configuration);

            planData.AddPlan(plan);

        }
    }
}
