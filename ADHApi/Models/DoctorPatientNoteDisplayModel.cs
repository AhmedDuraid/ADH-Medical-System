using System;

namespace ADHApi.Models
{
    public class DoctorPatientNoteDisplayModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public string PatientId { get; set; }
        public string AddedBy { get; set; }
        public bool ShowToPatient { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
    }
}
