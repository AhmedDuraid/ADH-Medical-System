using ADHApi.Error;
using ADHApi.Models.LabRequest;
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
    public class LabTestRequestController : ControllerBase
    {
        private readonly ILabTestRequestsData _labTestRequestsData;
        private readonly IApiErrorHandler _apiErrorHandler;

        // TODO before DELETE, Check request ID have same doctor id 

        public LabTestRequestController(ILabTestRequestsData labTestRequestsData, IApiErrorHandler apiErrorHandler)
        {
            _labTestRequestsData = labTestRequestsData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/LabTestRequest
        [HttpGet]
        [Authorize(Roles = "Admin, LabTester")]
        public IActionResult GetRequests()
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequests();

                if (LabRequest.Count > 0)
                {
                    return Ok(LabRequest);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Patient/{patientId}
        [HttpGet("Patient/{patientId}")]
        [Authorize(Roles = "Admin, Doctor, LabTester")]
        public IActionResult GetRequestsByPatientId(string patientId)
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequestByPatientId(patientId);

                if (LabRequest.Count > 0)
                {
                    return Ok(LabRequest);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Doctor/{doctorName}
        [HttpGet("Doctor/{doctorName}")]
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult GetRequestsByDoctorId(string doctorName)
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequestByDoctorId(doctorName);

                if (LabRequest.Count > 0)
                {
                    return Ok(LabRequest);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/LabTestRequest 
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNewRequest(ApiAddTestRequestsModel userInput)
        {
            try
            {
                var NewTestRequest = new LabTestRequestsModel()
                {
                    PatientId = userInput.PatientId,
                    TesterId = userInput.TestId,
                    CreatorID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                };

                _labTestRequestsData.AddTestRequests(NewTestRequest);

                return Ok($"lab Request Added to Patient {NewTestRequest.PatientId} ");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/LabTestRequest
        [HttpPut]
        [Authorize(Roles = "Tester")]
        public IActionResult UpdateRequestResults(APILabRequestUpdateModel userInput)
        {
            try
            {
                var UpdateRTest = new LabTestRequestsModel()
                {
                    TesterId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    Id = userInput.Id,
                    Result = userInput.Result
                };

                _labTestRequestsData.AddTestResults(UpdateRTest);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/LabTestRequest
        [Authorize(Roles = "Admin, Doctor")]
        [HttpDelete("{requestId}")]
        public IActionResult DeleteRequest(string requestId)
        {
            try
            {
                _labTestRequestsData.DeleteRequest(requestId);

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
