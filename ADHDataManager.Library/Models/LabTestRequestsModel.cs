using System;

namespace ADHDataManager.Library.Models
{
    public class LabTestRequestsModel
    {
        // main table 
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string Result { get; set; }
        public int CreatorID { get; set; }

        // relation table
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public DateTime ResultDate { get; set; }
        public string TesterId { get; set; }
        public string TesterFirstName { get; set; }
        public string TesterLastName { get; set; }
    }
}
