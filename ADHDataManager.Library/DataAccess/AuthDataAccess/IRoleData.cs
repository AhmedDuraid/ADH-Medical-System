using System.Threading.Tasks;

namespace ADHDataManager.Library.DataAccess.AuthDataAccess
{
    public interface IRoleData
    {
        Task AddNewRole<T>(T parameters, string procedureName);
        Task<T> FindRoleByID<T, U>(U parameters, string procedureName);
        Task<T> FindRoleByName<T, U>(U parameters, string procedureName);
    }
}