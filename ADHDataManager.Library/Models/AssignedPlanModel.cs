using System;

namespace ADHDataManager.Library.Models
{
    public class AssignedPlanModel
    {
        // table 
        public string Id { get; set; } = $"Plan{DateTime.Now.ToBinary()}";
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public string PlanId { get; set; }
        public DateTime StartOn { get; set; }

        // realation tables 
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string PlanType { get; set; }
    }
}
