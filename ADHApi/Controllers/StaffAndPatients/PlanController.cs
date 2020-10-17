using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly PlanData planData;


        public PlanController(IConfiguration configuration)
        {
            planData = new PlanData(configuration);
        }

        // GET: api/staffAndPatients/Plan/GetPlans
        [HttpGet]
        public IActionResult GetPlans()
        {
            var Plan = planData.GetPlans();

            return Ok(Plan);
        }

        // GET: api/staffAndPatients/Plan/GetPlanByType/type
        [HttpGet("{type}")]
        public IActionResult GetPlanByType(string type)
        {
            var Plan = planData.GetPlansByType(type);

            return Ok(Plan);
        }

        // POST: api/staffAndPatients/Plan/AddNew
        [HttpPost]
        public IActionResult AddNew([FromBody] PlanModel plan)
        {
            planData.AddPlan(plan);

            return Ok();
        }

        // PUT: api/staffAndPatients/Plan/UpdatePlan
        [HttpPut]
        public IActionResult UpdatePlan([FromBody] PlanModel plan)
        {
            planData.UpdatePlan(plan);

            return Ok();
        }

        // DELETE: api/staffAndPatients/Plan/DeletePlan
        [HttpPut("{id}")]
        public IActionResult DeletePlan(string id)
        {
            planData.DeletePlan(id);

            return Ok();
        }
    }
}
