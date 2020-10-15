using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class AssignedMedicineData
    {

        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        SqlDataAccess sqlDataAccess = new SqlDataAccess();

        public AssignedMedicineData(IConfiguration confugration)
        {
            _connectionString = confugration.GetConnectionString(connectionName);
        }



        public List<AssignedMedicineModel> GetAssignedMeds()
        {

            var Parameters = new { };

            var output = sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssignedMedicines_FindAll",
                Parameters,
                _connectionString);

            return output;

        }
        public List<AssignedMedicineModel> GetAssignedPatientId(string id)
        {

            var Parameters = new { @PatientId = id };

            var output = sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssignedMedicines_FindAllByPatientId",
                Parameters,
                _connectionString);

            return output;

        }

        public List<AssignedMedicineModel> GetAssignedDoctorId(string id)
        {

            var Parameters = new { @DoctorID = id };

            var output = sqlDataAccess.LoadData<AssignedMedicineModel, dynamic>("dbo.spAssignedMedicines_FindAllByDoctorId",
                Parameters,
                _connectionString);

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

            sqlDataAccess.SaveData<dynamic>("dbo.spAssignedMedicines_AddNew",
                Parameters,
                _connectionString);

        }
    }
}
