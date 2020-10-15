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
        public int Id { get; set; }
        public int DoctoreID { get; set; }
        public int MedicineId { get; set; }
        public int PatientId { get; set; }




    }
}
