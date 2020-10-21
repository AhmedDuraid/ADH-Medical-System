namespace ADHApi.Models
{
    public class ApiPatientNoteModel
    {
        public string Body { get; set; }
        public int PatientId { get; set; }
        public int AddedBy { get; set; }
        public bool ShowToPatient { get; set; }
    }
}
