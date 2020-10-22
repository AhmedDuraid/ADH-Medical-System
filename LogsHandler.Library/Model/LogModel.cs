using System;

namespace LogsHandler.Library.Model
{
    public class LogModel
    {
        public DateTime Date { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
    }
}
