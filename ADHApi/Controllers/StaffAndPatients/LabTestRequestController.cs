using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class LabTestRequestController : ControllerBase
    {
        private readonly ILabTestRequestsData _labTestRequestsData;

        public LabTestRequestController(ILabTestRequestsData labTestRequestsData)
        {
            _labTestRequestsData = labTestRequestsData;
        }

        // GET: api/staffAndPatients/LabTestRequest/GetRequests
        [HttpGet]
        public IActionResult GetRequests()
        {
            var LabRequest = _labTestRequestsData.GetTestRequests();

            return Ok(LabRequest);
        }

        // GET: api/staffAndPatients/LabTestRequest/GetRequestsBypatientId/patientId
        [HttpGet("{patientId}")]
        public IActionResult GetRequestsByPatientId(string patientId)
        {
            var LabRequest = _labTestRequestsData.GetTestRequestByPatientId(patientId);

            return Ok(LabRequest);
        }

        // GET: api/staffAndPatients/LabTestRequest/GetRequestsByDoctorId/patientName
        [HttpGet("{doctorName}")]
        public IActionResult GetRequestsByDoctorId(string doctorName)
        {
            var LabRequest = _labTestRequestsData.GetTestRequestByDoctorId(doctorName);

            return Ok(LabRequest);
        }

        // POST: api/staffAndPatients/LabTestRequest/AddNewRequest
        [HttpPost]
        public IActionResult AddNewRequest([FromBody] LabTestRequestsModel testRequest)
        {

            _labTestRequestsData.AddTestRequests(testRequest);

            return Ok();
        }

        // PUT: api/staffAndPatients/LabTestRequest/UpdateRequestResults
        [HttpPut]
        public IActionResult UpdateRequestResults([FromBody] LabTestRequestsModel testRequest)
        {

            _labTestRequestsData.AddTestResults(testRequest);

            return Ok();
        }

        // DELETE: api/staffAndPatients/LabTestRequest/UpdateRequestResults

        [HttpDelete("{requestId}")]
        public IActionResult DeleteRequest(string requestId)
        {

            _labTestRequestsData.DeleteRequest(requestId);

            return Ok();
        }
    }
}
