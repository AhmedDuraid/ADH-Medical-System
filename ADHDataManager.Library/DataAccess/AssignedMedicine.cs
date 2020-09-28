using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class AssignedMedicine
    {
        private readonly string DataConnectionName = "AHDConnection";

        public List<AssignedMedicineModel> GetAssignedMeds()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { };

            var output = sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssigned_GetAllAssignedMed",
                Parameters,
                DataConnectionName);

            return output;

        }
        public List<AssignedMedicineModel> GetAssignedMedByID(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @ID = id };

            var output = sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssigned_GetAssignedMedByID",
                Parameters,
                DataConnectionName);

            return output;

        }
        public void AddAssignedMed(AssignedMedicineModel assignedMedicine)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new
            {
                @PatientId = assignedMedicine.patient_id,
                @MedicineId = assignedMedicine.medicine_id,
                @UserID = assignedMedicine.user_id
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spAssigned_medicineAddNew",
                Parameters,
                DataConnectionName);

        }
    }
}
