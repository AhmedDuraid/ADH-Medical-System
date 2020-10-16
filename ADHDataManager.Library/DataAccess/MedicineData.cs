using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class MedicineData
    {

        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess sqlDataAccess;

        public MedicineData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(connectionName);
            sqlDataAccess = new SqlDataAccess();
        }


        public List<MedicineModel> GetMedicines()
        {
            var output = sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicines_FindAll",
                new { }, _connectionString);
            return output;
        }

        public List<MedicineModel> GetMedicineByName(string medName)
        {
            var Parameters = new { @MedName = medName };
            var output = sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicines_FindMedByName",
                Parameters, _connectionString);

            return output;
        }

        public void AddMedicines(MedicineModel medicine)
        {
            var Parameters = new
            {
                @Id = medicine.Id,
                @Name = medicine.Name,
                @Description = medicine.Description,
                @Contraindication = medicine.Contraindication,
                @RecommendedDose = medicine.RecommendedDose
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spMedicines_AddNewMed",
                Parameters, _connectionString);
        }

        public void UpdateMed(MedicineModel medicine)
        {
            var Parameters = new
            {
                @Name = medicine.Name,
                @Description = medicine.Description,
                @Contraindication = medicine.Contraindication,
                @RecommendedDose = medicine.RecommendedDose,
                @MedId = medicine.Id
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spMedicines_UpdateMed",
                Parameters, _connectionString);
        }
        public void DeleteMed(string medId)
        {
            var Parameters = new
            {
                @MedId = medId
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spMedicines_DeleteMed",
                Parameters, _connectionString);
        }
    }
}
