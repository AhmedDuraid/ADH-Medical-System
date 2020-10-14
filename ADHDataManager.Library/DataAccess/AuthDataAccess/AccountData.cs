using ADHDataManager.Library.Internal.DataAccess;
using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class AccountData
    {
        private readonly SqlDataAccess _sqlDataAccess = new SqlDataAccess();
        public async Task AddNewUser<T>(string connectionString, T parameters, string procedureName)
        {
            await _sqlDataAccess.SaveTaskData<T>(procedureName, parameters, connectionString);
        }

        public async Task<T> LoadUserByName<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>(procedureName, parameters, connectionString);
        }

        public async Task<T> LoadUserById<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>(procedureName, parameters, connectionString);
        }

        public async Task<T> LoadUserByEmail<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>(procedureName, parameters, connectionString);
        }
    }
}
