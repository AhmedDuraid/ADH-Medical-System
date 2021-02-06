using System;

namespace ADHApi.Models
{
    public class PatientAssignedPlanDisplayModel
    {
        public string PatientID { get; set; }
        public DateTime StartOn { get; set; }
        public string PatientFirstName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string PlanType { get; set; }
    }
}
