using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LabTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/LabTest
        [HttpGet]
        public List<LabTestModel> Get()
        {
            LabTestData labTest = new LabTestData();

            var tests = labTest.GetLabTests();

            return tests;
        }

        [HttpGet("{id}")]
        // GET: api/LabTest/{id}
        public List<LabTestModel> Get(int id)
        {
            LabTestData labTest = new LabTestData();

            var test = labTest.GetLabTestById(id);

            return test;
        }

        [HttpGet("{name}")]
        public List<LabTestModel> Get(string name)
        {
            LabTestData labTest = new LabTestData();

            var tests = labTest.GetLabTestByName(name);

            return tests;
        }

        // POST: api/LabTest
        [HttpPost]
        public void Post([FromBody] LabTestModel labTest)
        {
            LabTestData labTestDate = new LabTestData();

            labTestDate.AddNewTest(labTest);

        }
    }
}
