using System.ComponentModel.DataAnnotations;

namespace ADHApi.Models.AssignedMedicine
{
    public class ApiAddAssignedMedicineModel
    {
        [Required]
        public string DoctoreID { get; set; }

        [Required]
        public string MedicineId { get; set; }

        [Required]
        public string PatientId { get; set; }
    }
}
