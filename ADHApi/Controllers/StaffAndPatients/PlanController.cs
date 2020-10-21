using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanData _planData;


        public PlanController(IPlanData planData)
        {
            _planData = planData;
        }

        // GET: api/Plan/
        [HttpGet]
        [Authorize(Roles = "Admin, Doctor, Manager")]
        public IActionResult GetPlans()
        {
            var Plan = _planData.GetPlans();

            if (Plan.Count > 0)
            {
                return Ok(Plan);
            }

            return NotFound();
        }

        // GET: api/Plan/{type}
        [HttpGet("{type}")]
        [Authorize(Roles = "Admin, Doctor, Manager")]
        public IActionResult GetPlanByType(string type)
        {
            var Plan = _planData.GetPlansByType(type);

            if (Plan.Count > 0)
            {
                return Ok(Plan);
            }

            return NotFound();
        }

        // POST: api/Plan/
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult AddNew([FromBody] PlanModel userInput)
        {
            var NewPlan = new PlanModel()
            {
                Type = userInput.Type,
                Description = userInput.Description,
                Day1 = userInput.Day1,
                Day2 = userInput.Day2,
                Day3 = userInput.Day3,
                Day4 = userInput.Day4,
                Day5 = userInput.Day5,
                Day6 = userInput.Day6,
                Day7 = userInput.Day7
            };

            _planData.AddPlan(NewPlan);

            return Ok($"Plan added with and have the Id {NewPlan.Id} and type {NewPlan.Type}");
        }

        // PUT: api/Plan
        [HttpPut]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult UpdatePlan([FromBody] PlanModel plan)
        {
            _planData.UpdatePlan(plan);

            return Ok();
        }

        // DELETE: api/Plan/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult DeletePlan(string id)
        {
            _planData.DeletePlan(id);

            return Ok();
        }
    }
}
