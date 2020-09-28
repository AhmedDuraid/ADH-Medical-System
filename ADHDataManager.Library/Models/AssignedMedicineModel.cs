namespace ADHDataManager.Library.Models
{
    public class AssignedMedicineModel
    {
        // links 

        public string patient_first_name { get; set; }
        public string description { get; set; }
        public string user_first_name { get; set; }
        public string user_last_name { get; set; }

        // table
        public int assigned_id { get; set; }
        public int user_id { get; set; }
        public int medicine_id { get; set; }
        public int patient_id { get; set; }




    }
}
