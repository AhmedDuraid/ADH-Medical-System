using ADHApi.Models.LabRequest;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestRequestController : ControllerBase
    {
        private readonly ILabTestRequestsData _labTestRequestsData;

        // TODO create store procuders and connect to the database 

        public LabTestRequestController(ILabTestRequestsData labTestRequestsData)
        {
            _labTestRequestsData = labTestRequestsData;
        }

        // GET: api/LabTestRequest
        [HttpGet]
        [Authorize(Roles = "Admin, LabTester")]
        public IActionResult GetRequests()
        {
            var LabRequest = _labTestRequestsData.GetTestRequests();

            if (LabRequest.Count > 0)
            {
                return Ok(LabRequest);
            }

            return NotFound();
        }

        // GET: api/LabTestRequest/Patient/{patientId}
        [HttpGet("Patient/{patientId}")]
        [Authorize(Roles = "Admin, Doctor, LabTester")]
        public IActionResult GetRequestsByPatientId(string patientId)
        {
            var LabRequest = _labTestRequestsData.GetTestRequestByPatientId(patientId);

            if (LabRequest.Count > 0)
            {
                return Ok(LabRequest);
            }

            return NotFound();
        }

        // GET: api/LabTestRequest/Doctor/{doctorName}
        [HttpGet("Doctor/{doctorName}")]
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult GetRequestsByDoctorId(string doctorName)
        {
            var LabRequest = _labTestRequestsData.GetTestRequestByDoctorId(doctorName);

            if (LabRequest.Count > 0)
            {
                return Ok(LabRequest);
            }

            return NotFound();
        }

        // POST: api/LabTestRequest/query 
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNewRequest(ApiAddTestRequestsModel userInput)
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

        // PUT: api/LabTestRequest
        [HttpPut]
        [Authorize(Roles = "Tester")]
        public IActionResult UpdateRequestResults(APILabRequestUpdateModel userInput)
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

        // DELETE: api/LabTestRequest
        [Authorize(Roles = "Admin, Doctor")]
        [HttpDelete("{requestId}")]
        public IActionResult DeleteRequest(string requestId)
        {
            _labTestRequestsData.DeleteRequest(requestId);

            return Ok();
        }
    }
}
