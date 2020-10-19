using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADHDataManager.Library.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string procedureName, U procedureParameter);
        Task<T> LoadTaskData<T, U>(string procedureName, U procedureParameter);
        void SaveData<T>(string procedureName, T procedureParameter);
        Task SaveTaskData<T>(string procedureName, T procedureParameter);
    }
}