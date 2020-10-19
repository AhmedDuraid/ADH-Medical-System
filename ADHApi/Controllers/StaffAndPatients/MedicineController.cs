using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineData _medicineData;


        public MedicineController(IMedicineData medicineData)
        {
            _medicineData = medicineData;
        }

        // GET: api/staffAndPatients/Medicine/GetMedicines
        [HttpGet]
        public IActionResult GetMedicines()
        {
            var Medicines = _medicineData.GetMedicines();

            return Ok(Medicines);
        }

        // GET: api/staffAndPatients/Medicine/GetMedicineByName
        [HttpGet("{MedName}")]
        public IActionResult GetMedicineByName(string MedName)
        {
            var Medicine = _medicineData.GetMedicineByName(MedName);

            return Ok(Medicine);
        }

        // POST: api/staffAndPatients/Medicine/AddNew
        [HttpPost]
        public IActionResult AddNew([FromBody] MedicineModel medicine)
        {
            _medicineData.AddMedicines(medicine);

            return Ok();
        }

        // PUT: api/staffAndPatients/Medicine/UpdateMedicine
        [HttpPut]
        public IActionResult UpdateMedicine([FromBody] MedicineModel medicine)
        {
            _medicineData.UpdateMed(medicine);

            return Ok();
        }

        // DELETE: api/staffAndPatients/Medicine/DeleteMedicine
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(string id)
        {
            _medicineData.DeleteMed(id);

            return Ok();
        }

    }
}
