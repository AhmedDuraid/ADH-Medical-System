using System;

namespace ADHApi.Models.AssignedPlan
{
    public class ApiCreateAssignedPlanModel
    {
        public string PatientID { get; set; }
        public string PlanId { get; set; }
        public DateTime StartOn { get; set; }
    }
}
