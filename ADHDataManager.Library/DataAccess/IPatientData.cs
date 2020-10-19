using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IPatientData
    {
        List<PatientModel> GetPatientByID(string id);
        List<PatientModel> GetPatients();
    }
}