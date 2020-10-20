using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Manager, Doctor")]
    public class LabTestController : ControllerBase
    {
        private readonly ILabTestData _labTest;

        public LabTestController(ILabTestData labTestData)
        {
            _labTest = labTestData;
        }

        // GET: api/LabTest
        [HttpGet]
        public IActionResult GetTests()
        {
            var Tests = _labTest.GetTests();

            if (Tests.Count > 0)
            {
                return Ok(Tests);
            }

            return NotFound();
        }

        [HttpGet("{testName}")]
        // GET: api/LabTest/{testName}
        public IActionResult GetTestByName(string testName)
        {
            var test = _labTest.GetTestByName(testName);

            if (test.Count > 0)
            {
                return Ok(test);
            }

            return NotFound();
        }

        // POST: api/LabTest/Admin
        [HttpPost("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewTest([FromQuery] string testName, [FromQuery] string description)
        {
            var Test = new LabTestModel() { Description = description, TestName = testName };

            _labTest.AddNewTest(Test);

            return Ok();
        }

        // PUT: api/LabTest/Admin/{id}/?
        [HttpPut("Admin/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateTest(string id, string testName, string description)
        {
            var UpdatedTest = new LabTestModel() { Id = id, Description = description, TestName = testName };

            _labTest.UpdateTest(UpdatedTest);

            return Ok();
        }

        // DELETE: api/StaffAndPatients/LabTest/UpdateTest/id
        [HttpDelete("Admin/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTest(string id)
        {
            _labTest.DeleteTest(id);

            return Ok();
        }
    }
}
