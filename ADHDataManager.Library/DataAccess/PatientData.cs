using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientData
    {
        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess sqlDataAccess;


        public PatientData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(connectionName);
            sqlDataAccess = new SqlDataAccess();
        }

        public List<PatientModel> GetPatients()
        {
            var output = sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spUsersRole_FindPatinets",
                new { }, _connectionString);
            return output;
        }

        public List<PatientModel> GetPatientByID(string id)
        {
            var Parameters = new { @UserId = id };
            var output = sqlDataAccess.LoadData<PatientModel, dynamic>("dbo.spUsersRole_FindPatinetById",
                Parameters, _connectionString);

            return output;
        }

    }
}
