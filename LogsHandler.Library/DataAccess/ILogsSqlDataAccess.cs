using LogsHandler.Library.Model;
using System.Collections.Generic;

namespace LogsHandler.Library.DataAccess
{
    public interface ILogsSqlDataAccess
    {
        List<LogModel> LoadData();
        void SaveData(LogModel logModel);
    }
}