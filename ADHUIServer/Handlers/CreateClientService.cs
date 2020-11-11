using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ADHUIServer.Handlers
{
    public class CreateClientService : ICreateClientService
    {
        public HttpClient ApiClient { get; set; }
        public CreateClientService()
        {
            StartClient();
        }
        private void StartClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://localhost:5001");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
