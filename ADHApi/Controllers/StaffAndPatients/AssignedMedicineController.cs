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
    public class AssignedMedicineController : ControllerBase
    {
        private readonly IAssignedMedicineData _assignedMedicine;
        public AssignedMedicineController(IAssignedMedicineData assignedMedicineData)
        {
            _assignedMedicine = assignedMedicineData;

        }

        // GET: api/AssignedMedicine/Admin
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAssignedMed()
        {
            var assignedMedicines = _assignedMedicine.GetAssignedMeds();

            if (assignedMedicines != null)
            {
                return Ok(assignedMedicines);
            }

            return NotFound();
        }

        // GET: api/AssignedMedicine/Patient
        [HttpGet("patient")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetAssignedMedByPatientId()
        {
            var patientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var assignedMedicines = _assignedMedicine.GetAssignedPatientId(patientId);

            if (assignedMedicines != null)
            {
                return Ok(assignedMedicines);
            }
            return NotFound();
        }

        // GET: api/AssignedMedicine/Doctor
        [HttpGet("Doctor")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetAssignedMedByDoctorId()
        {
            var DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var assignedMedicines = _assignedMedicine.GetAssignedDoctorId(DoctorId);

            if (assignedMedicines != null)
            {
                Ok(assignedMedicines);
            }

            return NotFound();
        }

        // POST: api/AssignedMedicine
        [HttpPost]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult PostNewAssignedMed([FromBody] AssignedMedicineModel model)
        {
            if (ModelState.IsValid)
            {
                _assignedMedicine.AddAssignedMed(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult Delete(string id)
        {

            _assignedMedicine.DeleteAssignedMed(id);

            return Ok();
        }
    }
}
