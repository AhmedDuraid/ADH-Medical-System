using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestData
    {
        private readonly SqlDataAccess sqlDataAccess;
        public LabTestData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess(configuration);
        }

        public List<LabTestModel> GetTests()
        {
            var Parameters = new { };
            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_FindAll",
                Parameters);
            return output;
        }

        public List<LabTestModel> GetTestByName(string testName)
        {
            var Parameters = new { @TestName = testName };
            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_FindTestByName", Parameters);

            return output;
        }

        public void AddNewTest(LabTestModel labTest)
        {
            var Parameters = new
            {
                @TestId = labTest.Id,
                @TestName = labTest.TestName,
                @Description = labTest.Description
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_AddNewTest", Parameters);
        }

        public void UpdateTest(LabTestModel labTest)
        {
            var Parameters = new
            {
                @TestId = labTest.Id,
                @TestName = labTest.TestName,
                @Description = labTest.Description
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_UpdateTest", Parameters);
        }

        public void DeleteTest(string id)
        {
            var Parameters = new { @TestID = id };

            sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_DeleteTest", Parameters);
        }
    }
}
