using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestRequestsData
    {
        private readonly SqlDataAccess sqlDataAccess;
        public LabTestRequestsData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess(configuration);
        }


        public List<LabTestRequestsModel> GetTestRequests()
        {
            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAll", new { });

            return Output;
        }

        public List<LabTestRequestsModel> GetTestRequestByDoctorId(string doctorId)
        {
            var Parapeters = new { @DoctorID = doctorId };
            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAllByDoctorId", Parapeters);

            return Output;
        }

        public List<LabTestRequestsModel> GetTestRequestByPatientId(string patientName)
        {
            var Parapeters = new { @PatientID = patientName };
            var Output = sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAllByPatientId", Parapeters);

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

            sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_AddNewRequest", Parameter);
        }

        public void AddTestResults(LabTestRequestsModel data)
        {
            var Parameter = new
            {
                @Id = data.Id,
                @TesterId = data.TesterId,
                @Results = data.Result
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_UpdateResult", Parameter);
        }

        public void DeleteRequest(string requestId)
        {
            var Parameter = new
            {
                @Id = requestId
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_DeleteRequest", Parameter);
        }
    }
}
