using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestData
    {
        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess sqlDataAccess;
        public LabTestData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess();
            _connectionString = configuration.GetConnectionString(connectionName);
        }

        public List<LabTestModel> GetTests()
        {

            var Parameters = new { };

            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_FindAll",
                Parameters, _connectionString);
            return output;


        }

        public List<LabTestModel> GetTestByName(string testName)
        {
            var Parameters = new { @TestName = testName };

            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_FindTestByName",
                Parameters, _connectionString);
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

            sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_AddNewTest",
                Parameters, _connectionString);


        }

        public void UpdateTest(LabTestModel labTest)
        {

            var Parameters = new
            {
                @TestId = labTest.Id,
                @TestName = labTest.TestName,
                @Description = labTest.Description
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_UpdateTest",
                Parameters, _connectionString);


        }

        public void DeleteTest(string id)
        {
            var Parameters = new
            {
                @TestID = id
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spLabTests_DeleteTest",
                Parameters, _connectionString);


        }

    }
}
