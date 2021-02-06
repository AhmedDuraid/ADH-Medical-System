using ADHApi.Error;
using ADHApi.Models;
using ADHApi.ViewModels;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    // TODO     create function to update plan 
    public class AssignedPlanController : ControllerBase
    {


        private readonly IAssignedPlanData _assignedPlanData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public AssignedPlanController(IAssignedPlanData assignedPlanData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _assignedPlanData = assignedPlanData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/AssignedPlan/Admin
        [HttpGet]
        [Authorize(Roles = "Patient")]
        // return only plan that has patient ID
        public IActionResult GetAssignedPlans()
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var AssignedPlans = _assignedPlanData.GetAssignedPlansByPaitnetID(UserId);
                var model = _mapper.Map<PatientAssignedPlanDisplayModel>(AssignedPlans);

                if (AssignedPlans.Count > 0)
                {
                    return Ok(model);
                }

                return NotFound("No plans to show");


            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        [HttpGet("{patientId}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetByPatientID(string patientId)
        {
            try
            {
                var AssignedPlans = _assignedPlanData.GetAssignedPlansByPaitnetID(patientId);
                var model = _mapper.Map<DoctorAssignedPlanDisplayModel>(AssignedPlans);

                if (AssignedPlans.Count > 0)
                {
                    return Ok(model);
                }

                return NotFound("No plans for this patient");
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
        // return plans that has Doctor ID only 
        public IActionResult GetByDoctorID()
        {
            try
            {
                var DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var AssignedPlans = _assignedPlanData.GetAssignedPlansByDoctorID(DoctorId);

                var model = _mapper.Map<DoctorAssignedPlanDisplayModel>(AssignedPlans);

                if (AssignedPlans.Count > 0)
                {
                    return Ok(model);
                }

                return NotFound($"No plans found for this id: {DoctorId}");
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
        public IActionResult PostNewAssigne([FromBody] AssignedPlanViewModel input)
        {
            // TODO Check if the Patient in the database before you add plan 
            try
            {
                string DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var model = _mapper.Map<AssignedPlanModel>(input);
                model.DoctorID = DoctorId;

                _assignedPlanData.AddAssignedPlan(model);

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
        [Authorize(Roles = "Doctor")]
        public IActionResult Delete(string id)
        {
            // TODO Before DELETE APlan, check if  doctor create what he will delete  (PHASE 3)
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
