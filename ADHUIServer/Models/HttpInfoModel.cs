using System.Net;

namespace ADHUIServer.Models
{
    public class HttpInfoModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
