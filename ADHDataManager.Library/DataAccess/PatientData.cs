using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientData : IPatientData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PatientData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<PatientModel> GetPatients()
        {
            var output = _sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spUserRole_FindPatinets", new { });
            return output;
        }

        public List<PatientModel> GetPatientByID(string id)
        {
            var Parameters = new { @UserId = id };
            var output = _sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spUserRole_FindPatinetById", Parameters);

            return output;
        }
    }
}
