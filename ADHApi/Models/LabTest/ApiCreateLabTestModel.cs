using System.ComponentModel.DataAnnotations;

namespace ADHApi.Models.LabTest
{
    public class ApiCreateLabTestModel
    {
        [Required]
        public string TestName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
