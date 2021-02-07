using System;

namespace ADHApi.Models
{
    public class DoctorLabTestRequestsDisplayModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string PatientId { get; set; }
        public string Result { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public string TesterId { get; set; }
        public string TesterFirstName { get; set; }
        public string TesterLastName { get; set; }
    }
}
