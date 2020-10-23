using ADHApi.Error;
using ADHApi.Models.AssignedPlan;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignedPlanController : ControllerBase
    {
        // TODO Before create new plan check if the input PatientId is: Patient, he is in the Database (PHASE 3)
        // TODO Before DELETE APlan, check if  doctor create what he will delete  (PHASE 3)

        private readonly IAssignedPlanData _assignedPlanData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public AssignedPlanController(IAssignedPlanData assignedPlanData, IApiErrorHandler apiErrorHandler)
        {
            _assignedPlanData = assignedPlanData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/AssignedPlan/Admin
        [HttpGet]
        [Authorize(Roles = "Admin, Patient")]
        public IActionResult GetAssignedPlans()
        {
            string UserRole = User.FindFirst(ClaimTypes.Role)?.Value;
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<AssignedPlanModel> AssignedPlans;

            try
            {
                switch (UserRole)
                {
                    case "Admin":
                        {
                            AssignedPlans = _assignedPlanData.GetAssignedPlans();

                            if (AssignedPlans.Count > 0)
                            {
                                return Ok(AssignedPlans);

                            }
                            return NotFound();
                        }
                    case "Patient":
                        {
                            AssignedPlans = _assignedPlanData.GetAssignedPlansByPaitnetID(UserId);

                            if (AssignedPlans.Count > 0)
                            {
                                return Ok(AssignedPlans);
                            }

                            return NotFound();
                        }
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        [HttpGet("Doctor/{patientId}")]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult GetByPatientID(string patientId)
        {
            try
            {
                var AssignedPlans = _assignedPlanData.GetAssignedPlansByPaitnetID(patientId);

                if (AssignedPlans.Count > 0)
                {
                    return Ok(AssignedPlans);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/AssignedPlan/Doctor
        [HttpGet("Doctor")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetByDoctorID()
        {
            try
            {
                var DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var AssignedPlans = _assignedPlanData.GetAssignedPlansByDoctorID(DoctorId);

                if (AssignedPlans.Count > 0)
                {
                    return Ok(AssignedPlans);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/AssignedPlan
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public IActionResult PostNewAssigne([FromBody] ApiCreateAssignedPlanModel assignedPlanInput)
        {
            try
            {
                string DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var assignePlan = new AssignedPlanModel()
                {
                    PatientID = assignedPlanInput.PatientID,
                    PlanId = assignedPlanInput.PlanId,
                    DoctorID = DoctorId,
                    StartOn = assignedPlanInput.StartOn
                };

                _assignedPlanData.AddAssignedPlan(assignePlan);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);

        }

        // DELETE: api/AssignedPlan
        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor, Admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                _assignedPlanData.DeletePlan(id);

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
