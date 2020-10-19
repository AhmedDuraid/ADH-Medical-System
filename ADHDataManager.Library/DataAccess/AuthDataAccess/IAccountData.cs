using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public interface IAccountData
    {
        Task AddNewUser<T>(T parameters);
        Task<T> LoadUserByEmail<T, U>(U parameters);
        Task<T> LoadUserById<T, U>(U parameters);
        Task<T> LoadUserByName<T, U>(U parameters);
    }
}