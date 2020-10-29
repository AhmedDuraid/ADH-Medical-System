using System.Net.Http;

namespace UIDataAccess.Library.Services
{
    public interface ICreateClientService
    {
        HttpClient ApiClient { get; set; }
    }
}