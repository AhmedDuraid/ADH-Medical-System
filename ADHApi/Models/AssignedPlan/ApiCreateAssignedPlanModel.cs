using System;
using System.ComponentModel.DataAnnotations;

namespace ADHApi.Models.AssignedPlan
{
    public class ApiCreateAssignedPlanModel
    {
        [Required]
        public string PatientID { get; set; }

        [Required]
        public string PlanId { get; set; }

        [Required]
        public DateTime StartOn { get; set; }
    }
}
