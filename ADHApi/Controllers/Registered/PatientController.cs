using ADHApi.Error;
using ADHApi.Models.User;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientData _patientData;
        private readonly IUserData _userData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public PatientController(IPatientData patientData, IUserData userData, IApiErrorHandler apiErrorHandler)
        {
            _patientData = patientData;
            _userData = userData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/Patient
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPatients()
        {
            try
            {
                var Patients = _patientData.GetPatients();

                if (Patients.Count > 0)
                {
                    return Ok(Patients);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Patient/admin/{id}
        [HttpGet("Admin/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPatientByID(string id)
        {
            try
            {
                var Patient = _patientData.GetPatientByID(id);

                return Ok(Patient);
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Patient/{id}
        [HttpGet("PatientId")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetPatientByID()
        {
            try
            {
                var PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var Patient = _patientData.GetPatientByID(PatientId);

                if (Patient.Count > 0)
                {
                    return Ok(Patient);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        [HttpPut]
        [Authorize(Roles = "Patient")]
        public IActionResult UpdatePatient([FromBody] UserUpdateModel userInput)
        {
            try
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
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);

        }
    }
}
