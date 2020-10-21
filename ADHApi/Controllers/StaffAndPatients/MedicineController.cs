using ADHApi.Models;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineData _medicineData;


        public MedicineController(IMedicineData medicineData)
        {
            _medicineData = medicineData;
        }

        // GET: api/Medicine/
        [HttpGet]
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult GetMedicines()
        {
            var Medicines = _medicineData.GetMedicines();

            if (Medicines.Count > 0)
            {
                return Ok(Medicines);
            }

            return NotFound();
        }

        // GET: api/Medicine/MedName/{MedName}
        [HttpGet("MedName/{MedName}")]
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult GetMedicineByName(string MedName)
        {
            var Medicine = _medicineData.GetMedicineByName(MedName);

            if (Medicine.Count > 0)
            {
                return Ok(Medicine);

            }

            return NotFound();
        }

        // POST: api/staffAndPatients/Medicine/AddNew
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNew([FromBody] ApiMedicineModel userInput)
        {
            var NewMed = new MedicineModel()
            {
                Name = userInput.Name,
                Contraindication = userInput.Contraindication,
                Description = userInput.Description,
                RecommendedDose = userInput.RecommendedDose
            };

            _medicineData.AddMedicines(NewMed);

            return Ok();
        }

        // PUT: api/Medicine/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateMedicine(string id, [FromBody] ApiMedicineModel userInput)
        {
            var UpdateMed = new MedicineModel()
            {
                Id = id,
                Description = userInput.Description,
                Name = userInput.Name,
                Contraindication = userInput.Contraindication,
                RecommendedDose = userInput.RecommendedDose
            };
            _medicineData.UpdateMed(UpdateMed);

            return Ok();
        }

        // DELETE: api/Medicine/
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMedicine(string id)
        {
            _medicineData.DeleteMed(id);

            return Ok();
        }

    }
}
