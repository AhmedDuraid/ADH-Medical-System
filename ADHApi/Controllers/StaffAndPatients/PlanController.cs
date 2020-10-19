using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanData _planData;


        public PlanController(IPlanData planData)
        {
            _planData = planData;
        }

        // GET: api/staffAndPatients/Plan/GetPlans
        [HttpGet]
        public IActionResult GetPlans()
        {
            var Plan = _planData.GetPlans();

            return Ok(Plan);
        }

        // GET: api/staffAndPatients/Plan/GetPlanByType/type
        [HttpGet("{type}")]
        public IActionResult GetPlanByType(string type)
        {
            var Plan = _planData.GetPlansByType(type);

            return Ok(Plan);
        }

        // POST: api/staffAndPatients/Plan/AddNew
        [HttpPost]
        public IActionResult AddNew([FromBody] PlanModel plan)
        {
            _planData.AddPlan(plan);

            return Ok();
        }

        // PUT: api/staffAndPatients/Plan/UpdatePlan
        [HttpPut]
        public IActionResult UpdatePlan([FromBody] PlanModel plan)
        {
            _planData.UpdatePlan(plan);

            return Ok();
        }

        // DELETE: api/staffAndPatients/Plan/DeletePlan
        [HttpPut("{id}")]
        public IActionResult DeletePlan(string id)
        {
            _planData.DeletePlan(id);

            return Ok();
        }
    }
}
