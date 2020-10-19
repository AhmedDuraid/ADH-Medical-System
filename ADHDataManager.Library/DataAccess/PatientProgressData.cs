using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientProgressData : IPatientProgressData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PatientProgressData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<PatientProgressModel> GetPatientProgresses()
        {
            var output = _sqlDataAccess.LoadData<PatientProgressModel, dynamic>("dbo.spPatientProgress_FindAll", new { });

            return output;
        }

        public List<PatientProgressModel> GetPatientProgressesByPatientId(string patientId)
        {
            var Parameters = new { @PatientId = patientId };
            var output = _sqlDataAccess.LoadData<PatientProgressModel, dynamic>("dbo.spPatientProgress_FindAllByPatientId", Parameters);

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

            _sqlDataAccess.SaveData<dynamic>("dbo.spPatientProgress_AddNew", Parameters);
        }

        public void DeleteProgress(string progressId)
        {
            var Parameters = new { @ProgressId = progressId };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPatientProgress_DeleteByID", Parameters);
        }
    }
}
