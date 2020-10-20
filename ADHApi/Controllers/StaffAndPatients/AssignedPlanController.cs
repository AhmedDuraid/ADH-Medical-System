using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignedPlanController : ControllerBase
    {

        private readonly IAssignedPlanData _assignedPlanData;

        public AssignedPlanController(IAssignedPlanData assignedPlanData)
        {
            _assignedPlanData = assignedPlanData;
        }

        // GET: api/AssignedPlan/Admin
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAssignedPlans()
        {
            var AssignedPlans = _assignedPlanData.GetAssignedPlans();

            if (AssignedPlans.Count > 0)
            {
                return Ok(AssignedPlans);

            }
            return NotFound();
        }

        // GET: api/AssignedPlan/Patient
        [HttpGet("Patient")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetByPatientID()
        {
            var PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var AssignedPlans = _assignedPlanData.GetAssignedPlansByPaitnetID(PatientId);

            if (AssignedPlans.Count > 0)
            {
                return Ok(AssignedPlans);
            }

            return NotFound();
        }

        [HttpGet("Doctor/{patientId}")]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult GetByPatientID(string patientId)
        {
            var AssignedPlans = _assignedPlanData.GetAssignedPlansByPaitnetID(patientId);

            if (AssignedPlans.Count > 0)
            {
                return Ok(AssignedPlans);
            }

            return NotFound();
        }

        // GET: api/AssignedPlan/Doctor
        [HttpGet("Doctor")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetByDoctorID()
        {
            var DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var AssignedPlans = _assignedPlanData.GetAssignedPlansByDoctorID(DoctorId);

            if (AssignedPlans.Count > 0)
            {
                return Ok(AssignedPlans);
            }

            return NotFound();
        }

        // POST: api/AssignedPlan
        [HttpPost]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult PostNewAssigne([FromBody] AssignedPlanModel assigned)
        {
            var assignePlan = new AssignedPlanModel()
            {
                PatientID = assigned.PatientID,
                PlanId = assigned.PlanId,
                DoctorID = assigned.DoctorID,
                StartOn = assigned.StartOn
            };
            _assignedPlanData.AddAssignedPlan(assignePlan);

            return Ok();

        }

        // DELETE: api/AssignedPlan
        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult Delete(string id)
        {
            _assignedPlanData.DeletePlan(id);

            return Ok();
        }
    }
}
