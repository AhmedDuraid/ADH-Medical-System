using ADHApi.Error;
using ADHApi.Models;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientProgressController : ControllerBase
    {
        private readonly IPatientProgressData _patientProgressData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public PatientProgressController(IPatientProgressData patientProgressData, IApiErrorHandler apiErrorHandler)
        {
            _patientProgressData = patientProgressData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/PatientProgress/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetProgress()
        {
            try
            {
                List<PatientProgressModel> Progresses = _patientProgressData.GetPatientProgresses();

                if (Progresses.Count > 0)
                {
                    return Ok(Progresses);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/PatientProgress/Patient

        [HttpGet("Patient")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetByPatientID()
        {
            try
            {
                string PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                List<PatientProgressModel> Progresses = _patientProgressData.GetPatientProgressesByPatientId(PatientId);

                if (Progresses.Count > 0)
                {
                    return Ok(Progresses);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/PatientProgress/
        [HttpGet("Staff/{patientID}")]
        [Authorize(Roles = "Admin, Doctor, Manager")]
        public IActionResult GetByPatientID(string patientID)
        {
            try
            {
                List<PatientProgressModel> Progresses = _patientProgressData.GetPatientProgressesByPatientId(patientID);

                if (Progresses.Count > 0)
                {
                    return Ok(Progresses);

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }


        // POST: api/PatientProgress/
        [HttpPost("Patient")]
        [Authorize(Roles = "Patient")]
        public IActionResult AddNew([FromBody] ApiPatientProgressModel userInput)
        {
            string PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            PatientProgressModel NewProgress = new PatientProgressModel()
            {
                BMI = userInput.BMI,
                Weight = userInput.Weight,
                PatientId = PatientId,
                AddedBy = PatientId
            };


            _patientProgressData.AddProgress(NewProgress);

            return Ok();
        }

        // POST: api/PatientProgress/
        [HttpPost("{patientId}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNew(string patientId, [FromBody] ApiPatientProgressModel userInput)
        {

            try
            {
                PatientProgressModel NewProgress = new PatientProgressModel()
                {
                    BMI = userInput.BMI,
                    Weight = userInput.Weight,
                    PatientId = patientId,
                    AddedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                };

                _patientProgressData.AddProgress(NewProgress);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }
        // DELETE: api/PatientProgress
        //admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProgress(string id)
        {
            try
            {
                _patientProgressData.DeleteProgress(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }
    }
}
