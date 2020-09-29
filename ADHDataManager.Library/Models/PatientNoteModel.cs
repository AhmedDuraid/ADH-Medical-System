using System;

namespace ADHDataManager.Library.Models
{
    public class PatientNoteModel
    {
        // table 
        public int note_id { get; set; }
        public DateTime date { get; set; }
        public string note_body { get; set; }
        public int patient_Id { get; set; }
        public int user_ID { get; set; }

        // realtion table 
        public string patient_first_name { get; set; }
        public string user_first_name { get; set; }
    }
}
