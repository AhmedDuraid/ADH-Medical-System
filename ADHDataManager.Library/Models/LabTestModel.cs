using System;

namespace ADHDataManager.Library.Models
{
    public class LabTestModel
    {
        public string Id { get; set; } = $"Test{DateTime.Now.ToBinary()}";
        public string TestName { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }


    }
}
