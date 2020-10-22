using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class AssignedMedicineData : IAssignedMedicineData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public AssignedMedicineData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<AssignedMedicineModel> GetAssignedMeds()
        {
            var Parameters = new { };
            var output = _sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssignedMedicines_FindAll", Parameters);

            return output;
        }
        public List<AssignedMedicineModel> GetAssignedPatientId(string id)
        {
            var Parameters = new { @PatientId = id };
            var output = _sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssignedMedicines_FindAllByPatientId", Parameters);

            return output;
        }

        public List<AssignedMedicineModel> GetAssignedDoctorId(string id)
        {
            var Parameters = new { @DoctorID = id };
            var output = _sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssignedMedicines_FindAllByDoctorId", Parameters);

            return output;
        }

        public List<AssignedMedicineModel> GetAssignedById(string id)
        {
            var Parameters = new { @Id = id };
            var output = _sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssignedMedicines_FindByID", Parameters);

            return output;
        }
        public void AddAssignedMed(AssignedMedicineModel assignedMedicine)
        {
            var Parameters = new
            {
                @Id = assignedMedicine.Id,
                @PatientId = assignedMedicine.PatientId,
                @MedicineId = assignedMedicine.MedicineId,
                @AddedBy = assignedMedicine.DoctoreID
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spAssignedMedicines_AddNew", Parameters);
        }

        public void DeleteAssignedMed(string assignedId)
        {
            _sqlDataAccess.SaveData<dynamic>("dbo.spAssignedMedicines_Delete", new { @AssignedId = assignedId });

        }
    }
}
