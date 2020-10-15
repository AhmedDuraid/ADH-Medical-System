using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/staffAndPatients/[controller]/[action]")]
    [ApiController]
    public class AssignedPlanController : ControllerBase
    {

        private readonly AssignedPlanData assignedPlanData;

        public AssignedPlanController(IConfiguration configuration)
        {
            assignedPlanData = new AssignedPlanData(configuration);
        }

        // GET: api/staffAndPatients/AssignedPlan/GetAssignedPlans
        [HttpGet]
        public IActionResult GetAssignedPlans()
        {

            var AssignedPlans = assignedPlanData.GetAssignedPlans();

            return Ok(AssignedPlans);
        }

        // GET: api/staffAndPatients/AssignedPlan/GetAssignedPlans
        [HttpGet("{patientId}")]
        public IActionResult GetByPatientID(string patientId)
        {
            var AssignedPlans = assignedPlanData.GetAssignedPlansByPaitnetID(patientId);

            return Ok(AssignedPlans);
        }

        // GET: api/staffAndPatients/AssignedPlan/GetByDoctorID
        [HttpGet("{doctorID}")]
        public IActionResult GetByDoctorID(string doctorID)
        {
            var AssignedPlans = assignedPlanData.GetAssignedPlansByDoctorID(doctorID);

            return Ok(AssignedPlans);
        }

        // POST: api/staffAndPatients/AssignedPlan/GetAssignedPlans
        [HttpPost]
        public IActionResult PostNewAssigne([FromBody] AssignedPlanModel assigned)
        {

            assignedPlanData.AddAssignedPlan(assigned);

            return Ok();

        }
    }
}
