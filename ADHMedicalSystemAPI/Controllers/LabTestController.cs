using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/LabTest")]
    public class LabTestController : ApiController
    {
        // GET: api/LabTest
        public List<LabTestModel> Get()
        {
            LabTestData labTest = new LabTestData();

            var tests = labTest.GetLabTests();

            return tests;
        }

        // GET: api/LabTest/{id}
        public List<LabTestModel> Get(int id)
        {
            LabTestData labTest = new LabTestData();

            var test = labTest.GetLabTestById(id);

            return test;
        }

        public List<LabTestModel> Get(string name)
        {
            LabTestData labTest = new LabTestData();

            var tests = labTest.GetLabTestByName(name);

            return tests;
        }
        // POST: api/LabTest
        public void Post([FromBody] LabTestModel labTest)
        {
            LabTestData labTestDate = new LabTestData();

            labTestDate.AddNewTest(labTest);

        }
    }
}
