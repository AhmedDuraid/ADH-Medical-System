namespace ADHDataManager.Library.Models
{
    public class AssignedMedicineModel
    {
        // links 

        // Patient

        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }

        // Doctor

        public string DoctoreFirstName { get; set; }
        public string DoctoreLastNameName { get; set; }

        // Medicine
        public string MedicineDescription { get; set; }
        public string MedicineName { get; set; }


        // table
        public string Id { get; set; }
        public string DoctoreID { get; set; }
        public string MedicineId { get; set; }
        public string PatientId { get; set; }




    }
}
