using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IPatientProgressData
    {
        void AddProgress(PatientProgressModel progress);
        void DeleteProgress(string progressId);
        List<PatientProgressModel> GetPatientProgresses();
        List<PatientProgressModel> GetPatientProgressesByPatientId(string patientId);
    }
}