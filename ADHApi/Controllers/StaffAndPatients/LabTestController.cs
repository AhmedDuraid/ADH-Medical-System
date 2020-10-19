using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {
        private readonly ILabTestData _labTest;

        public LabTestController(ILabTestData labTestData)
        {
            _labTest = labTestData;
        }

        // GET: api/StaffAndPatients/LabTest/GetTests
        [HttpGet]
        public IActionResult GetTests()
        {

            var Tests = _labTest.GetTests();

            return Ok(Tests);
        }

        [HttpGet("{testName}")]
        // GET: api/StaffAndPatients/LabTest/GetTestByName/testName
        public IActionResult GetTestByName(string testName)
        {

            var test = _labTest.GetTestByName(testName);

            return Ok(test);
        }

        // POST: api/StaffAndPatients/LabTest/AddNewTest
        [HttpPost]
        public IActionResult AddNewTest([FromBody] LabTestModel testInfo)
        {
            _labTest.AddNewTest(testInfo);

            return Ok();
        }

        // PUT: api/StaffAndPatients/LabTest/UpdateTest
        [HttpPut]
        public IActionResult UpdateTest([FromBody] LabTestModel testInfo)
        {
            _labTest.UpdateTest(testInfo);

            return Ok();
        }

        // DELETE: api/StaffAndPatients/LabTest/UpdateTest/testId
        [HttpDelete("{testId}")]
        public IActionResult DeleteTest(string testId)
        {
            _labTest.DeleteTest(testId);

            return Ok();
        }
    }
}
