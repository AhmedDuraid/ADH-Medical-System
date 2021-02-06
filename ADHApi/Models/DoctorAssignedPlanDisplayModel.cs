using System;

namespace ADHApi.Models
{
    public class DoctorAssignedPlanDisplayModel
    {
        public string Id { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public string PlanId { get; set; }
        public DateTime StartOn { get; set; }
        public string PlanType { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
    }
}
