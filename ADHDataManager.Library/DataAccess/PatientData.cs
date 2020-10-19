using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientData
    {
        private readonly SqlDataAccess sqlDataAccess;

        public PatientData(IConfiguration configuration)
        {
            sqlDataAccess = new SqlDataAccess(configuration);
        }

        public List<PatientModel> GetPatients()
        {
            var output = sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spUsersRole_FindPatinets", new { });
            return output;
        }

        public List<PatientModel> GetPatientByID(string id)
        {
            var Parameters = new { @UserId = id };
            var output = sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spUsersRole_FindPatinetById", Parameters);

            return output;
        }
    }
}
