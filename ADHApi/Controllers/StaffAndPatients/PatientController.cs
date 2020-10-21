using ADHApi.Models.User;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientData _patientData;
        private readonly IUserData _userData;

        public PatientController(IPatientData patientData, IUserData userData)
        {
            _patientData = patientData;
            _userData = userData;
        }

        // GET: api/Patient
        [HttpGet]
        [Authorize(Roles = "Admin, Patient")]
        public IActionResult GetPatients()
        {
            var Patients = _patientData.GetPatients();

            if (Patients.Count > 0)
            {
                return Ok(Patients);
            }

            return NotFound();
        }

        // GET: api/Patient/admin/{id}
        [HttpGet("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPatientByID(string id)
        {
            var Patient = _patientData.GetPatientByID(id);

            return Ok(Patient);
        }

        // GET: api/Patient/{id}
        [HttpGet("PatientId")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetPatientByID()
        {
            var PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Patient = _patientData.GetPatientByID(PatientId);

            if (Patient.Count > 0)
            {
                return Ok(Patient);
            }

            return NotFound();
        }

        [HttpPut]
        [Authorize(Roles = "Patient")]
        public IActionResult UpdatePatient([FromBody] UserUpdateModel userInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var UserInfo = new UserModel()
            {
                Id = UserId,
                FirstName = userInput.FirstName,
                MiddleName = userInput.MiddleName,
                LastName = userInput.LastName,
                BirthDate = userInput.BirthDate,
                PhoneNumber = userInput.PhoneNumber,
                Gender = userInput.Gender,
                Nationality = userInput.Nationality,
                Address = userInput.Address
            };

            _userData.UpdateUser(UserInfo);

            return Ok($"{UserId} information Updated ");

        }
    }
}
