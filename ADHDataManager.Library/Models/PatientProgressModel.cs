using System;

namespace ADHDataManager.Library.Models
{
    public class PatientProgressModel
    {
        // table 
        public string Id { get; set; } = $"Progress{DateTime.Now.ToBinary()}";
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
        public string PatientId { get; set; }
        public string AddedBy { get; set; }


        // realation tables 

        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
    }
}
