using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class PatientProgressController : ControllerBase
    {
        private readonly PatientProgressData patientProgressData;


        public PatientProgressController(IConfiguration configuration)
        {
            patientProgressData = new PatientProgressData(configuration);
        }

        // GET: api/staffAndPatients/PatientProgress/GetProgress
        [HttpGet]
        public IActionResult GetProgress()
        {
            var Progresses = patientProgressData.GetPatientProgresses();

            return Ok(Progresses);
        }

        // GET: api/staffAndPatients/PatientProgress/GetByPatientID

        [HttpGet("{patientID}")]
        public IActionResult GetByPatientID(string patientID)
        {
            var Progresses = patientProgressData.GetPatientProgressesByPatientId(patientID);

            return Ok(Progresses);
        }

        // POST: api/staffAndPatients/PatientProgress/AddNew
        [HttpPost]
        public IActionResult AddNew([FromBody] PatientProgressModel patientProgress)
        {
            patientProgressData.AddProgress(patientProgress);

            return Ok();
        }

        // DELETE: api/staffAndPatients/PatientProgress/DeleteProgress
        //admin
        [HttpDelete("{id}")]
        public IActionResult DeleteProgress(string id)
        {
            patientProgressData.DeleteProgress(id);

            return Ok();
        }
    }
}
