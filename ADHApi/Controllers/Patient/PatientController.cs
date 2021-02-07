using ADHApi.Error;
using ADHApi.Models;
using ADHDataManager.Library.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ADHApi.Controllers.Patient
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Patient")]
    public class PatientController : ControllerBase
    {
        private readonly LabTestRequestsData _labTestRequestsData;
        private readonly ApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public PatientController(LabTestRequestsData labTestRequestsData,
            ApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _labTestRequestsData = labTestRequestsData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/Patient/{patientId}
        [HttpGet("LabRequests/{patientId}")]
        public IActionResult GetRequestsByPatientId(string patientId)
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequestByPatientId(patientId);

                var model = _mapper.Map<List<PatientLabTestRequestsDisplayModel>>(LabRequest);

                if (LabRequest.Count > 0)
                {
                    return Ok(model);
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
