using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {
        private readonly LabTestData labTest;

        public LabTestController(IConfiguration configuration)
        {
            labTest = new LabTestData(configuration);
        }

        // GET: api/StaffAndPatients/LabTest/GetTests
        [HttpGet]
        public IActionResult GetTests()
        {

            var Tests = labTest.GetTests();

            return Ok(Tests);
        }

        [HttpGet("{testName}")]
        // GET: api/StaffAndPatients/LabTest/GetTestByName/testName
        public IActionResult GetTestByName(string testName)
        {

            var test = labTest.GetTestByName(testName);

            return Ok(test);
        }

        // POST: api/StaffAndPatients/LabTest/AddNewTest
        [HttpPost]
        public IActionResult AddNewTest([FromBody] LabTestModel testInfo)
        {
            labTest.AddNewTest(testInfo);

            return Ok();
        }

        // PUT: api/StaffAndPatients/LabTest/UpdateTest
        [HttpPut]
        public IActionResult UpdateTest([FromBody] LabTestModel testInfo)
        {
            labTest.UpdateTest(testInfo);

            return Ok();
        }

        // DELETE: api/StaffAndPatients/LabTest/UpdateTest/testId
        [HttpDelete("{testId}")]
        public IActionResult DeleteTest(string testId)
        {
            labTest.DeleteTest(testId);

            return Ok();
        }
    }
}
