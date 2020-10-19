using ADHDataManager.Library.Internal.DataAccess;
using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public class AccountData : IAccountData
    {

        private readonly ISqlDataAccess _sqlDataAccess;

        public AccountData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public async Task AddNewUser<T>(T parameters)
        {
            await _sqlDataAccess.SaveTaskData<T>("dbo.spUsers_AddUser_Auth", parameters);
        }

        public async Task<T> LoadUserByName<T, U>(U parameters)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>("dbo.spUsers_GetUserByName_Auth", parameters);
        }

        public async Task<T> LoadUserById<T, U>(U parameters)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>("dbo.spUsers_GetUserById_Auth", parameters);
        }

        public async Task<T> LoadUserByEmail<T, U>(U parameters)
        {
            return await _sqlDataAccess.LoadTaskData<T, U>("dbo.spUsers_GetUserByEmail_Auth", parameters);
        }
    }
}
