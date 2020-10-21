using System;

namespace ADHDataManager.Library.Models
{
    public class MedicineModel
    {
        public string Id { get; set; } = $"Med{DateTime.Now.ToBinary()}";
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contraindication { get; set; }
        public string RecommendedDose { get; set; }
    }
}
