using ADHApi.Error;
using ADHApi.Models;
using ADHApi.ViewModels;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using AutoMapper;
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
        // TODO :   Add Assigned Med By ID
        private readonly IAssignedMedicineData _assignedMedicine;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public AssignedMedicineController(IAssignedMedicineData assignedMedicineData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _assignedMedicine = assignedMedicineData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/AssignedMedicine
        [HttpGet]
        [Authorize(Roles = "Patient, Doctor")]
        public IActionResult GetAssignedMed()
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<AssignedMedicineModel> assignedMedicines;
            string RoleType = ClaimTypes.Role.ToString();

            try
            {
                if (User.HasClaim(RoleType, "Patient"))
                {
                    assignedMedicines = _assignedMedicine.GetAssignedPatientId(UserId);

                    var model = _mapper.Map<PatientAssignedMedicineDisplayModel>(assignedMedicines);

                    if (assignedMedicines.Count > 0)
                    {
                        return Ok(model);
                    }

                    return NotFound();
                }

                if (User.HasClaim(RoleType, "Doctor"))
                {
                    assignedMedicines = _assignedMedicine.GetAssignedDoctorId(UserId);

                    if (assignedMedicines.Count > 0)
                    {
                        Ok(assignedMedicines);
                    }
                    return NotFound();
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
        [Authorize(Roles = "Doctor")]
        public IActionResult PostNewAssignedMed([FromBody] AssignedMedicineViewModel input)
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {

                var model = _mapper.Map<AssignedMedicineModel>(input);
                model.DoctoreID = UserId;

                _assignedMedicine.AddAssignedMed(model);

                return Ok($"Added");

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
                string UserID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (AssignedMed == null)
                {
                    return NotFound($"There is to Assigned Medicine with this ID {id} ");
                }

                if (AssignedMed[0].DoctoreID != UserID)
                {
                    return NotFound($"You user {UserID} CAN'T DELETE This Record {id}");
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
