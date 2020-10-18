using ADHDataManager.Library.Internal.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class AccountData
    {
        private readonly SqlDataAccess _sqlDataAccess;
        private readonly string _connectionName = "AHDConnection";
        private readonly string _connectionString;

        public AccountData(IConfiguration configuration)
        {
            _sqlDataAccess = new SqlDataAccess();
            _connectionString = configuration.GetConnectionString(_connectionName);
        }
        public async Task AddNewUser<T>(T parameters)
        {
            await _sqlDataAccess.SaveTaskData<T>("dbo.spUsers_AddUser_Auth", parameters, _connectionString);
        }

        public async Task<T> LoadUserByName<T, U>(U parameters)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>("dbo.spUsers_GetUserByName_Auth", parameters, _connectionString);
        }

        public async Task<T> LoadUserById<T, U>(U parameters)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>("dbo.spUsers_GetUserById_Auth", parameters, _connectionString);
        }

        public async Task<T> LoadUserByEmail<T, U>(U parameters)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>("dbo.spUsers_GetUserByEmail_Auth", parameters, _connectionString);
        }
    }
}
