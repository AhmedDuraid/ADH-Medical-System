using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Medicine")]
    public class MedicineController : ApiController
    {
        // GET: api/Medicine
        public List<MedicineModel> Get()
        {
            MedicineData medicineData = new MedicineData();

            var Medicines = medicineData.GetMedicines();

            return Medicines;
        }

        // GET: api/Medicine/{id}
        public List<MedicineModel> Get(int id)
        {
            MedicineData medicineData = new MedicineData();

            var Medicine = medicineData.GetMedicineByID(id);

            return Medicine;
        }

        // GET: api/Medicine/5
        public List<MedicineModel> Get(string medName)
        {
            MedicineData medicineData = new MedicineData();

            var Medicine = medicineData.GetMedicineByName(medName);

            return Medicine;
        }

        // POST: api/Medicine
        public void Post([FromBody] MedicineModel medicine)
        {
            MedicineData medicineData = new MedicineData();

            medicineData.AddMedicines(medicine);
        }

    }
}
