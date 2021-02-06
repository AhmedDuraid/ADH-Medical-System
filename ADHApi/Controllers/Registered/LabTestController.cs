using ADHApi.Error;
using ADHApi.Models.LabTest;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Manager, Doctor")]
    public class LabTestController : ControllerBase
    {
        private readonly ILabTestData _labTest;
        private readonly IApiErrorHandler _apiErrorHandler;

        public LabTestController(ILabTestData labTestData, IApiErrorHandler apiErrorHandler)
        {
            _labTest = labTestData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/LabTest
        [HttpGet]
        public IActionResult GetTests()
        {
            try
            {
                var Tests = _labTest.GetTests();

                if (Tests.Count > 0)
                {
                    return Ok(Tests);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        [HttpGet("{testName}")]
        // GET: api/LabTest/{testName}
        public IActionResult GetTestByName(string testName)
        {
            try
            {
                var test = _labTest.GetTestByName(testName);

                if (test.Count > 0)
                {
                    return Ok(test);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/LabTest/Admin
        [HttpPost("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewTest(ApiCreateLabTestModel labTestInput)
        {
            try
            {
                var Test = new LabTestModel() { Description = labTestInput.Description, TestName = labTestInput.Description };

                _labTest.AddNewTest(Test);

                return Ok("Created");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/LabTest/Admin/{id}
        [HttpPut("Admin/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateTest(string id, ApiCreateLabTestModel labTestInput)
        {
            try
            {
                var UpdatedTest = new LabTestModel()
                {
                    Id = id,
                    Description = labTestInput.Description,
                    TestName = labTestInput.TestName
                };

                _labTest.UpdateTest(UpdatedTest);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/LabTest/id
        [HttpDelete("Admin/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTest(string id)
        {
            try
            {
                _labTest.DeleteTest(id);

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
