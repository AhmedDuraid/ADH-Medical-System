using ADHApi.Error;
using ADHDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager, Doctor")]
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
    }
}
