using System;

namespace ADHApi.Models
{
    public class PrivateArticelDisplayModel
    {
        public string Id { get; set; }
        public string Titel { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Show { get; set; }
    }
}
