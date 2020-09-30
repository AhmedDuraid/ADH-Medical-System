namespace ADHDataManager.Library.Models
{
    public class AssignedPlanModel
    {
        // table 
        public int assign_id { get; set; }
        public int patient_Id { get; set; }
        public int plan_id { get; set; }

        // realation tables 
        public string patient_first_name { get; set; }
        public string patient_last_name { get; set; }
        public string plan_description { get; set; }
    }
}
