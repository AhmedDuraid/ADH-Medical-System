using ADHDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly PatientData patientData;

        public PatientController(IConfiguration configuration)
        {
            patientData = new PatientData(configuration);
        }

        // GET: api/staffAndPatients/Patient/GetPatients
        [HttpGet]
        public IActionResult GetPatients()
        {
            var Patients = patientData.GetPatients();

            return Ok(Patients);
        }

        // GET: api/staffAndPatients/Patient/GetPatientByID/id
        [HttpGet("{id}")]
        public IActionResult GetPatientByID(string id)
        {
            var Patient = patientData.GetPatientByID(id);

            return Ok(Patient);
        }
    }
}
