using System;

namespace ADHDataManager.Library.Models
{
    public class LabTestRequestsModel
    {
        // main table 
        public int request_id { get; set; }
        public DateTime date { get; set; }
        public int patient_id { get; set; }
        public int test_id { get; set; }
        public string test_result { get; set; }
        public int user_id { get; set; }

        // relation table
        public string patient_first_name { get; set; }
        public string patient_last_name { get; set; }
        public string test_name { get; set; }
        public string description { get; set; }
        public string user_first_name { get; set; }
    }
}
