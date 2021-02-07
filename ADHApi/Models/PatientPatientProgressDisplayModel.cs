using System;

namespace ADHApi.Models
{
    public class PatientPatientProgressDisplayModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
        public string PatientId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
    }
}
