using ADHApi.Error;
using ADHDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class PatientInfoController : ControllerBase
    {
        private readonly IPatientData _patientData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public PatientInfoController(IPatientData patientData, IApiErrorHandler apiErrorHandler)
        {
            _patientData = patientData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/PatientInfo/{id}
        [HttpGet("{id}")]
        public IActionResult GetPatientByID(string id)
        {
            try
            {
                var Patient = _patientData.GetPatientByID(id);

                return Ok(Patient);
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }
    }
}
