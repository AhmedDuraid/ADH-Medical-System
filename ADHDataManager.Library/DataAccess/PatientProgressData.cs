using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientProgressData
    {

        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess sqlDataAccess;

        public PatientProgressData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(connectionName);
            sqlDataAccess = new SqlDataAccess();
        }

        public List<PatientProgressModel> GetPatientProgresses()
        {
            var output = sqlDataAccess.LoadData<PatientProgressModel, dynamic>("dbo.spPatientProgress_FindAll",
                new { }, _connectionString);
            return output;
        }

        public List<PatientProgressModel> GetPatientProgressesByPatientId(string patientId)
        {
            var Parameters = new { @PatientId = patientId };

            var output = sqlDataAccess.LoadData<PatientProgressModel, dynamic>("dbo.spPatientProgress_FindAllByPatientId",
                Parameters, _connectionString);
            return output;

        }

        public void AddProgress(PatientProgressModel progress)
        {
            var Parameters = new
            {
                @Id = progress.Id,
                @Weight = progress.Weight,
                @BMI = progress.BMI,
                @PatientId = progress.PatientId,
                @AddedBy = progress.AddedBy
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientProgress_AddNew",
                    Parameters, _connectionString);
        }

        public void DeleteProgress(string progressId)
        {
            var Parameters = new { @ProgressId = progressId };

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientProgress_DeleteByID",
                    Parameters, _connectionString);
        }
    }
}
