using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IMedicineData
    {
        void AddMedicines(MedicineModel medicine);
        void DeleteMed(string medId);
        List<MedicineModel> GetMedicineByName(string medName);
        List<MedicineModel> GetMedicines();
        void UpdateMed(MedicineModel medicine);
    }
}