using System;

namespace ADHDataManager.Library.Models
{
    public class PatientProgressModel
    {
        // table 
        public int progress_id { get; set; }
        public DateTime date { get; set; }
        public float weight { get; set; }
        public float bmi { get; set; }
        public string added_by { get; set; }

        // realation tables 
        public int patient_Id { get; set; }
        public int user_id { get; set; }
        public string patient_first_name { get; set; }


    }
}
