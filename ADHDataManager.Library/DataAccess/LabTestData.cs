using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestData : ILabTestData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public LabTestData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<LabTestModel> GetTests()
        {
            var Parameters = new { };
            var output = _sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_FindAll",
                Parameters);
            return output;
        }

        public List<LabTestModel> GetTestByName(string testName)
        {
            var Parameters = new { @TestName = testName };
            var output = _sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_FindTestByName", Parameters);

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

            _sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_AddNewTest", Parameters);
        }

        public void UpdateTest(LabTestModel labTest)
        {
            var Parameters = new
            {
                @TestId = labTest.Id,
                @TestName = labTest.TestName,
                @Description = labTest.Description
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_UpdateTest", Parameters);
        }

        public void DeleteTest(string id)
        {
            var Parameters = new { @TestID = id };

            _sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_DeleteTest", Parameters);
        }
    }
}
