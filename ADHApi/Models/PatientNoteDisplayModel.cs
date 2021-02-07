using System;

namespace ADHApi.Models
{
    public class PatientNoteDisplayModel
    {
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public string PatientId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
    }
}
