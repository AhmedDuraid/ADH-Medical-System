using ADHApi.Error;
using ADHDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ADHApi.Controllers.Registered
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
        [Authorize(Roles = "Doctor")]
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
        [Authorize(Roles = "Doctor")]
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
    }
}
