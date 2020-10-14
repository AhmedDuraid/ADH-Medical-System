using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientData
    {
        private readonly string ConnectionName = "AHDConnection";

        public List<PatientModel> GetPatients()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spPatients_GetPatients",
                new { }, ConnectionName);
            return output;


        }

        public List<PatientModel> GetPatientByID(int id)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new { @PatientId = id };

            var output = sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spPatients_GetPatientByID",
                Parameters, ConnectionName);
            return output;


        }
        public void AddPatient(PatientModel patient)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            var Parameters = new
            {
                @FirstName = patient.first_name,
                @LastName = patient.last_name,
                @DirthDate = patient.birth_date,
                @Gender = patient.gender,
                @Email = patient.email,
                @Nationality = patient.nationality,
                @Weight = patient.weight,
                @Height = patient.height,
                @Bmi = patient.bmi,
                @UserName = patient.user_name,
                @Password = patient.password,
                @MiddleName = patient.middle_name
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spPatients_AddPatient",
                Parameters, ConnectionName);
        }
    }
}
