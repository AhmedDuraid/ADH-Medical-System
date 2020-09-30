﻿using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestData
    {
        private readonly string ConnectionName = "AHDConnection";

        public List<LabTestModel> GetLabTests()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { };

            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_GetAllTests",
                Parameters, ConnectionName);
            return output;


        }
        public List<LabTestModel> GetLabTestById(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @LabID = id };

            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_GetTestByID",
                Parameters, ConnectionName);
            return output;

        }
        public List<LabTestModel> GetLabTestByName(string testName)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @TestName = testName };

            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_GetTestByName",
                Parameters, ConnectionName);
            return output;

        }

        public void AddNewTest(LabTestModel labTest)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new
            {
                @TestName = labTest.test_name,
                @Description = labTest.description
            };

            var output = sqlDataAccess.LoadData<LabTestModel, dynamic>("dbo.spLabTests_AddNewTest",
                Parameters, ConnectionName);


        }

    }
}
