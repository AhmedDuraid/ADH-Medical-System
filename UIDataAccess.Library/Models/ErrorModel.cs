using System.Net;

namespace UIDataAccess.Library.Models
{
    public class ErrorModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
