using System;

namespace ADHDataManager.Library.Models
{
    public class PatientModel
    {
        public int patient_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string nationality { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public double bmi { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }

    }
}
