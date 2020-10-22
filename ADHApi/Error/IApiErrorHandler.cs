namespace ADHApi.Error
{
    public interface IApiErrorHandler
    {
        void CreateError(string source, string stackTrace, string message);
    }
}