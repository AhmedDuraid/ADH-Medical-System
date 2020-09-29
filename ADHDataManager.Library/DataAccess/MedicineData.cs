using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class MedicineData
    {

        private readonly string ConnectionName = "AHDConnection";

        public List<MedicineModel> GetMedicines()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();


            var output = sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicine_GetAllMed",
                new { }, ConnectionName);
            return output;


        }

        public List<MedicineModel> GetMedicineByID(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @MedID = id };

            var output = sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicine_GetMedByID",
                Parameters, ConnectionName);
            return output;


        }
        public List<MedicineModel> GetMedicineByName(string name)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @MedName = name };

            var output = sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicine_GetMedByName",
                Parameters, ConnectionName);
            return output;


        }
        public void AddMedicines(MedicineModel medicine)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new
            {
                @MedName = medicine.name,
                @MedDescription = medicine.description,
                @MedContraindication = medicine.contraindication
            };

            sqlDataAccess.LoadData<MedicineModel, dynamic>("dbo.spMedicine_InsertNewMed",
                Parameters, ConnectionName);



        }
    }
}
