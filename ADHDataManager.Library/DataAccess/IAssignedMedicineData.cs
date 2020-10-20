using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IAssignedMedicineData
    {
        void AddAssignedMed(AssignedMedicineModel assignedMedicine);
        void DeleteAssignedMed(string assignedId);
        List<AssignedMedicineModel> GetAssignedDoctorId(string id);
        List<AssignedMedicineModel> GetAssignedMeds();
        List<AssignedMedicineModel> GetAssignedPatientId(string id);
    }
}