using ADHApi.Error;
using ADHApi.Models.AssignedMedicine;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignedMedicineController : ControllerBase
    {
        private readonly IAssignedMedicineData _assignedMedicine;
        private readonly IApiErrorHandler _apiErrorHandler;

        public AssignedMedicineController(IAssignedMedicineData assignedMedicineData, IApiErrorHandler apiErrorHandler)
        {
            _assignedMedicine = assignedMedicineData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/AssignedMedicine/Admin
        [HttpGet]
        [Authorize(Roles = "Admin, Patient, Doctor")]
        public IActionResult GetAssignedMed()
        {
            string UserRole = User.FindFirst(ClaimTypes.Role)?.Value;
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<AssignedMedicineModel> assignedMedicines;

            try
            {
                switch (UserRole)
                {
                    case "Admin":
                        {
                            assignedMedicines = _assignedMedicine.GetAssignedMeds();

                            if (assignedMedicines != null)
                            {
                                return Ok(assignedMedicines);
                            }

                            return NotFound();
                        }
                    case "Patient":
                        {
                            assignedMedicines = _assignedMedicine.GetAssignedPatientId(UserId);

                            if (assignedMedicines != null)
                            {
                                return Ok(assignedMedicines);
                            }

                            return NotFound();

                        }
                    case "Doctor":
                        {
                            assignedMedicines = _assignedMedicine.GetAssignedDoctorId(UserId);

                            if (assignedMedicines != null)
                            {
                                Ok(assignedMedicines);
                            }
                            return NotFound();
                        }
                }
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }



        // POST: api/AssignedMedicine
        [HttpPost]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult PostNewAssignedMed([FromBody] ApiAddAssignedMedicineModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AssignedMedicineModel med = new()
                    {
                        PatientId = model.PatientId,
                        MedicineId = model.MedicineId,
                        DoctoreID = model.DoctoreID
                    };

                    _assignedMedicine.AddAssignedMed(med);

                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                var AssignedMed = _assignedMedicine.GetAssignedById(id);
                string UserRole = User.FindFirst(ClaimTypes.Role)?.Value;
                string UserID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (AssignedMed == null)
                {
                    return NotFound($"There is to Assigned Medicine with this ID {id} ");
                }

                // if user is admin
                if (UserRole == "Admin")
                {
                    _assignedMedicine.DeleteAssignedMed(id);

                    return Ok($"{id} Deleted");
                }

                // if user not admin 
                if (AssignedMed[0].DoctoreID != UserID)
                {
                    return BadRequest($"You user {UserID} CAN'T DELETE This Record {id}");
                }

                _assignedMedicine.DeleteAssignedMed(id);

                return Ok($"{id} Deleted");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);

        }
    }
}
