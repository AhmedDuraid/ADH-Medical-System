using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly MedicineData medicineData;


        public MedicineController(IConfiguration configuration)
        {
            medicineData = new MedicineData(configuration);
        }

        // GET: api/staffAndPatients/Medicine/GetMedicines
        [HttpGet]
        public IActionResult GetMedicines()
        {
            var Medicines = medicineData.GetMedicines();

            return Ok(Medicines);
        }

        // GET: api/staffAndPatients/Medicine/GetMedicineByName
        [HttpGet("{MedName}")]
        public IActionResult GetMedicineByName(string MedName)
        {
            var Medicine = medicineData.GetMedicineByName(MedName);

            return Ok(Medicine);
        }

        // POST: api/staffAndPatients/Medicine/AddNew
        [HttpPost]
        public IActionResult AddNew([FromBody] MedicineModel medicine)
        {
            medicineData.AddMedicines(medicine);

            return Ok();
        }

        // PUT: api/staffAndPatients/Medicine/UpdateMedicine
        [HttpPut]
        public IActionResult UpdateMedicine([FromBody] MedicineModel medicine)
        {
            medicineData.UpdateMed(medicine);

            return Ok();
        }

        // DELETE: api/staffAndPatients/Medicine/DeleteMedicine
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(string id)
        {
            medicineData.DeleteMed(id);

            return Ok();
        }

    }
}
