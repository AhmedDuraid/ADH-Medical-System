using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/staffAndPatients/[controller]/[action]")]
    [ApiController]
    public class AssignedPlanController : ControllerBase
    {

        private readonly IAssignedPlanData _assignedPlanData;

        public AssignedPlanController(IAssignedPlanData assignedPlanData)
        {
            _assignedPlanData = assignedPlanData;
        }

        // GET: api/staffAndPatients/AssignedPlan/GetAssignedPlans
        [HttpGet]
        public IActionResult GetAssignedPlans()
        {

            var AssignedPlans = _assignedPlanData.GetAssignedPlans();

            return Ok(AssignedPlans);
        }

        // GET: api/staffAndPatients/AssignedPlan/GetAssignedPlans
        [HttpGet("{patientId}")]
        public IActionResult GetByPatientID(string patientId)
        {
            var AssignedPlans = _assignedPlanData.GetAssignedPlansByPaitnetID(patientId);

            return Ok(AssignedPlans);
        }

        // GET: api/staffAndPatients/AssignedPlan/GetByDoctorID
        [HttpGet("{doctorID}")]
        public IActionResult GetByDoctorID(string doctorID)
        {
            var AssignedPlans = _assignedPlanData.GetAssignedPlansByDoctorID(doctorID);

            return Ok(AssignedPlans);
        }

        // POST: api/staffAndPatients/AssignedPlan/GetAssignedPlans
        [HttpPost]
        public IActionResult PostNewAssigne([FromBody] AssignedPlanModel assigned)
        {

            _assignedPlanData.AddAssignedPlan(assigned);

            return Ok();

        }
    }
}
