using System;

namespace ADHDataManager.Library.Models
{
    public class PatientNoteModel
    {
        // table 
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public int PatientId { get; set; }
        public int AddedBy { get; set; }
        public bool ShowToPatient { get; set; }

        // realtion table 
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
    }
}
