using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class PatientProgressController : ControllerBase
    {
        private readonly IPatientProgressData _patientProgressData;


        public PatientProgressController(IPatientProgressData patientProgressData)
        {
            _patientProgressData = patientProgressData;
        }

        // GET: api/staffAndPatients/PatientProgress/GetProgress
        [HttpGet]
        public IActionResult GetProgress()
        {
            var Progresses = _patientProgressData.GetPatientProgresses();

            return Ok(Progresses);
        }

        // GET: api/staffAndPatients/PatientProgress/GetByPatientID

        [HttpGet("{patientID}")]
        public IActionResult GetByPatientID(string patientID)
        {
            var Progresses = _patientProgressData.GetPatientProgressesByPatientId(patientID);

            return Ok(Progresses);
        }

        // POST: api/staffAndPatients/PatientProgress/AddNew
        [HttpPost]
        public IActionResult AddNew([FromBody] PatientProgressModel patientProgress)
        {
            _patientProgressData.AddProgress(patientProgress);

            return Ok();
        }

        // DELETE: api/staffAndPatients/PatientProgress/DeleteProgress
        //admin
        [HttpDelete("{id}")]
        public IActionResult DeleteProgress(string id)
        {
            _patientProgressData.DeleteProgress(id);

            return Ok();
        }
    }
}
