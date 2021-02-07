using ADHApi.Error;
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
    public class PatientProgressController : ControllerBase
    {
        // TODO
        private readonly IPatientProgressData _patientProgressData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public PatientProgressController(IPatientProgressData patientProgressData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _patientProgressData = patientProgressData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/PatientProgress/{patientID}
        [HttpGet("{patientID}")]
        [Authorize(Roles = "Doctor, Manager")]
        public IActionResult GetByPatientID(string patientID)
        {
            try
            {
                List<PatientProgressModel> Progresses = _patientProgressData.GetPatientProgressesByPatientId(patientID);

                if (Progresses.Count > 0)
                {
                    return Ok(Progresses);

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/PatientProgress/
        [HttpPost("{patientId}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNew(string patientId, [FromBody] PatientProgressViewModel userInput)
        {
            try
            {
                var model = _mapper.Map<PatientProgressModel>(userInput);
                model.PatientId = patientId;
                model.AddedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _patientProgressData.AddProgress(model);

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
