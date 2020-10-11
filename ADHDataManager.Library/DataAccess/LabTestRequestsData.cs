using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestRequestsData
    {

        private readonly string ConnectionName = "AHDConnection";
        private readonly IConfiguration _configuration;

        public LabTestRequestsData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<LabTestRequestsModel> GetLabTestRequests()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spLabTestRequests_GetAll",
                new { }, ConnectionName);

            return Output;
        }

        public List<LabTestRequestsModel> GetLabTestRequestByID(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parapeters = new { @ID = id };

            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spLabTestRequests_GetRequestByID",
                Parapeters, ConnectionName);

            return Output;

        }
        public void AddLabTestRequests(LabTestRequestsModel data)
        {

            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);
            var Parameter = new
            {
                @PatientID = data.patient_id,
                @TestID = data.test_id,
                @TestResult = data.test_result,
                @UserId = data.user_id
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spLabTestRequests_AddNewRequest",
                Parameter, ConnectionName);
        }
    }
}
