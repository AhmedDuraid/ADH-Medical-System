namespace ADHApi.Models.PatientNotes
{
    public class ApiAddPatientNoteModel
    {
        public string Body { get; set; }
        public string PatientId { get; set; }
        public bool ShowToPatient { get; set; }
    }
}
