using System;

namespace ADHApi.Models
{
    public class PatientLabTestRequestsDisplayModel
    {
        public string PatientId { get; set; }
        public string Result { get; set; }
        public string PatientFirstName { get; set; }
        public string TestName { get; set; }
        public DateTime ResultDate { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
    }
}
