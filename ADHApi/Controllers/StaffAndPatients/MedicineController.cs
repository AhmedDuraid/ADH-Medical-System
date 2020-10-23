using ADHApi.Error;
using ADHApi.Models.Medicine;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineData _medicineData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public MedicineController(IMedicineData medicineData, IApiErrorHandler apiErrorHandler)
        {
            _medicineData = medicineData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/Medicine/
        [HttpGet]
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult GetMedicines()
        {
            try
            {
                var Medicines = _medicineData.GetMedicines();

                if (Medicines.Count > 0)
                {
                    return Ok(Medicines);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Medicine/MedName/{MedName}
        [HttpGet("MedName/{MedName}")]
        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult GetMedicineByName(string MedName)
        {
            var Medicine = _medicineData.GetMedicineByName(MedName);

            try
            {
                if (Medicine.Count > 0)
                {
                    return Ok(Medicine);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Medicine/
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNew([FromBody] ApiMedicineModel userInput)
        {
            try
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
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/Medicine/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateMedicine(string id, [FromBody] ApiMedicineModel userInput)
        {
            try
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
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/Medicine/
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMedicine(string id)
        {
            try
            {
                _medicineData.DeleteMed(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

    }
}
