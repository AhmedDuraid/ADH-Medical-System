using AuthDataAccess.Library.Internal.SqlDataAccess;
using System.Threading.Tasks;

namespace AuthDataAccess.Library.DataAccess
{
    public class UserDataAccess
    {
        private readonly SqlDataAccess _sqlDataAccess;
        public UserDataAccess()
        {
            _sqlDataAccess = new SqlDataAccess();

        }

        public async Task AddNewUser<T>(string connectionString, T parameters, string procedureName)
        {
            await _sqlDataAccess.SaveData<T>(connectionString, procedureName, parameters);
        }

        public async Task<T> LoadUserByName<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadData<T, U>(parameters, connectionString, procedureName);
        }

        public async Task<T> LoadUserById<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadData<T, U>(parameters, connectionString, procedureName);
        }

        public async Task<T> LoadUserByEmail<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await _sqlDataAccess.LoadData<T, U>(parameters, connectionString, procedureName);
        }
    }
}
