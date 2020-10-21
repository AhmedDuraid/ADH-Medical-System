using ADHApi.Models;
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
    public class PatientProgressController : ControllerBase
    {
        private readonly IPatientProgressData _patientProgressData;


        public PatientProgressController(IPatientProgressData patientProgressData)
        {
            _patientProgressData = patientProgressData;
        }

        // GET: api/PatientProgress/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetProgress()
        {
            var Progresses = _patientProgressData.GetPatientProgresses();

            if (Progresses.Count > 0)
            {
                return Ok(Progresses);
            }

            return NotFound();
        }

        // GET: api/PatientProgress/Patient

        [HttpGet("Patient")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetByPatientID()
        {
            var PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Progresses = _patientProgressData.GetPatientProgressesByPatientId(PatientId);

            if (Progresses.Count > 0)
            {
                return Ok(Progresses);
            }

            return NotFound();
        }

        // GET: api/PatientProgress/
        [HttpGet("Staff/{patientID}")]
        [Authorize(Roles = "Admin, Doctor, Manager")]
        public IActionResult GetByPatientID(string patientID)
        {
            var Progresses = _patientProgressData.GetPatientProgressesByPatientId(patientID);

            if (Progresses.Count > 0)
            {
                return Ok(Progresses);

            }

            return NotFound();
        }


        // POST: api/PatientProgress/
        [HttpPost]
        [Authorize(Roles = "Patient, Doctor")]
        public IActionResult AddNew([FromBody] ApiPatientProgressModel userInput)
        {

            var NewProgress = new PatientProgressModel()
            {
                BMI = userInput.BMI,
                Weight = userInput.Weight,
                PatientId = userInput.PatientId,
                AddedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            };


            _patientProgressData.AddProgress(NewProgress);

            return Ok();
        }

        // DELETE: api/PatientProgress
        //admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProgress(string id)
        {
            _patientProgressData.DeleteProgress(id);

            return Ok();
        }
    }
}
