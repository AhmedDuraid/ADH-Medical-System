using ADHDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientData _patientData;

        public PatientController(IPatientData patientData)
        {
            _patientData = patientData;
        }

        // GET: api/staffAndPatients/Patient/GetPatients
        [HttpGet]
        public IActionResult GetPatients()
        {
            var Patients = _patientData.GetPatients();

            return Ok(Patients);
        }

        // GET: api/staffAndPatients/Patient/GetPatientByID/id
        [HttpGet("{id}")]
        public IActionResult GetPatientByID(string id)
        {
            var Patient = _patientData.GetPatientByID(id);

            return Ok(Patient);
        }
    }
}
