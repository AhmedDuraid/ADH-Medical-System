using System.Net.Http;

namespace ADHUIServer.Handlers
{
    public interface ICreateClientService
    {
        HttpClient ApiClient { get; set; }
    }
}