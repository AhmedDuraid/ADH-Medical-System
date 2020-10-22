using LogsHandler.Library.DataAccess;
using LogsHandler.Library.Model;

namespace ADHApi.Error
{
    public class ApiErrorHandler : IApiErrorHandler
    {
        private readonly ILogsSqlDataAccess _logsSqlDataAccess;

        public ApiErrorHandler(ILogsSqlDataAccess logsSqlDataAccess)
        {
            _logsSqlDataAccess = logsSqlDataAccess;
        }

        public void CreateError(string source, string stackTrace, string message)
        {
            var error = new LogModel()
            {
                Source = source,
                StackTrace = stackTrace,
                Message = message
            };
            _logsSqlDataAccess.SaveData(error);
        }
    }
}
