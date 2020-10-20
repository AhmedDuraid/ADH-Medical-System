using System;

namespace ADHDataManager.Library.Models
{
    public class LabTestModel
    {
        public string Id { get; set; } = DateTime.Now.ToBinary().ToString();
        public string TestName { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }


    }
}
