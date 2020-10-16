using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestRequestsData
    {

        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess sqlDataAccess;
        public LabTestRequestsData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess();
            _connectionString = configuration.GetConnectionString(connectionName);
        }


        public List<LabTestRequestsModel> GetTestRequests()
        {

            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAll",
                new { }, _connectionString);

            return Output;
        }

        public List<LabTestRequestsModel> GetTestRequestByDoctorId(string doctorId)
        {
            var Parapeters = new { @DoctorID = doctorId };

            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAllByDoctorId",
                Parapeters, _connectionString);

            return Output;

        }

        public List<LabTestRequestsModel> GetTestRequestByPatientId(string patientName)
        {
            var Parapeters = new { @PatientID = patientName };

            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAllByPatientId",
                Parapeters, _connectionString);

            return Output;

        }
        public void AddTestRequests(LabTestRequestsModel data)
        {
            var Parameter = new
            {
                @Id = data.Id,
                @PatientId = data.PatientId,
                @TestId = data.TesterId,
                @CreatorID = data.CreatorID
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_AddNewRequest",
                Parameter, _connectionString);
        }

        public void AddTestResults(LabTestRequestsModel data)
        {
            var Parameter = new
            {
                @Id = data.Id,
                @TesterId = data.TesterId,
                @Results = data.Result
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_UpdateResult",
                Parameter, _connectionString);
        }

        public void DeleteRequest(string requestId)
        {
            var Parameter = new
            {
                @Id = requestId
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_DeleteRequest",
                Parameter, _connectionString);
        }
    }
}
