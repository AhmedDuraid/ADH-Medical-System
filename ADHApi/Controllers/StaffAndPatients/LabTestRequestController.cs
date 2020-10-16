using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class LabTestRequestController : ControllerBase
    {
        private readonly LabTestRequestsData labTestRequests;

        public LabTestRequestController(IConfiguration configuration)
        {
            labTestRequests = new LabTestRequestsData(configuration);
        }

        // GET: api/staffAndPatients/LabTestRequest/GetRequests
        [HttpGet]
        public IActionResult GetRequests()
        {
            var LabRequest = labTestRequests.GetTestRequests();

            return Ok(LabRequest);
        }

        // GET: api/staffAndPatients/LabTestRequest/GetRequestsBypatientId/patientId
        [HttpGet("{patientId}")]
        public IActionResult GetRequestsByPatientId(string patientId)
        {
            var LabRequest = labTestRequests.GetTestRequestByPatientId(patientId);

            return Ok(LabRequest);
        }

        // GET: api/staffAndPatients/LabTestRequest/GetRequestsByDoctorId/patientName
        [HttpGet("{doctorName}")]
        public IActionResult GetRequestsByDoctorId(string doctorName)
        {
            var LabRequest = labTestRequests.GetTestRequestByDoctorId(doctorName);

            return Ok(LabRequest);
        }

        // POST: api/staffAndPatients/LabTestRequest/AddNewRequest
        [HttpPost]
        public IActionResult AddNewRequest([FromBody] LabTestRequestsModel testRequest)
        {

            labTestRequests.AddTestRequests(testRequest);

            return Ok();
        }

        // PUT: api/staffAndPatients/LabTestRequest/UpdateRequestResults
        [HttpPut]
        public IActionResult UpdateRequestResults([FromBody] LabTestRequestsModel testRequest)
        {

            labTestRequests.AddTestResults(testRequest);

            return Ok();
        }

        // DELETE: api/staffAndPatients/LabTestRequest/UpdateRequestResults

        [HttpDelete("{requestId}")]
        public IActionResult DeleteRequest(string requestId)
        {

            labTestRequests.DeleteRequest(requestId);

            return Ok();
        }
    }
}
