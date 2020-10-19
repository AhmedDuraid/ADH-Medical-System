using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class MedicineData : IMedicineData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public MedicineData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }


        public List<MedicineModel> GetMedicines()
        {
            var output = _sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicines_FindAll", new { });
            return output;
        }

        public List<MedicineModel> GetMedicineByName(string medName)
        {
            var Parameters = new { @MedName = medName };
            var output = _sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicines_FindMedByName", Parameters);

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

            _sqlDataAccess.SaveData<dynamic>("dbo.spMedicines_AddNewMed", Parameters);
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

            _sqlDataAccess.SaveData<dynamic>("dbo.spMedicines_UpdateMed", Parameters);
        }
        public void DeleteMed(string medId)
        {
            var Parameters = new
            {
                @MedId = medId
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spMedicines_DeleteMed", Parameters);
        }
    }
}
