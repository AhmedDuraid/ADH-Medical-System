using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface ILabTestRequestsData
    {
        void AddTestRequests(LabTestRequestsModel data);
        void AddTestResults(LabTestRequestsModel data);
        void DeleteRequest(string requestId);
        List<LabTestRequestsModel> GetTestRequestByDoctorId(string doctorId);
        List<LabTestRequestsModel> GetTestRequestByPatientId(string patientName);
        List<LabTestRequestsModel> GetTestRequests();
    }
}