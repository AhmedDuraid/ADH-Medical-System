using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class LabTestRequestsData : ILabTestRequestsData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public LabTestRequestsData(ISqlDataAccess sqlDataAccess)
        {

            _sqlDataAccess = sqlDataAccess;
        }


        public List<LabTestRequestsModel> GetTestRequests()
        {
            var Output = _sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAll", new { });

            return Output;
        }

        public List<LabTestRequestsModel> GetTestRequestByDoctorId(string doctorId)
        {
            var Parapeters = new { @DoctorID = doctorId };
            var Output = _sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAllByDoctorId", Parapeters);

            return Output;
        }

        public List<LabTestRequestsModel> GetTestRequestByPatientId(string patientName)
        {
            var Parapeters = new { @PatientID = patientName };
            var Output = _sqlDataAccess.LoadData<LabTestRequestsModel, dynamic>("dbo.spTestRequests_FindAllByPatientId", Parapeters);

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

            _sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_AddNewRequest", Parameter);
        }

        public void AddTestResults(LabTestRequestsModel data)
        {
            var Parameter = new
            {
                @Id = data.Id,
                @TesterId = data.TesterId,
                @Results = data.Result
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_UpdateResult", Parameter);
        }

        public void DeleteRequest(string requestId)
        {
            var Parameter = new
            {
                @Id = requestId
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spTestRequests_DeleteRequest", Parameter);
        }
    }
}
