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
    public class LabTestRequestController : ControllerBase
    {
        private readonly ILabTestRequestsData _labTestRequestsData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;

        public LabTestRequestController(ILabTestRequestsData labTestRequestsData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _labTestRequestsData = labTestRequestsData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/LabTestRequest
        [HttpGet]
        [Authorize(Roles = "LabTester")]
        public IActionResult GetRequests()
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequests();

                if (LabRequest.Count > 0)
                {
                    return Ok(LabRequest);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Patient/{patientId}
        [HttpGet("Patient/{patientId}")]
        [Authorize(Roles = "Doctor, LabTester")]
        public IActionResult GetRequestsByPatientId(string patientId)
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequestByPatientId(patientId);

                var model = _mapper.Map<List<DoctorLabTestRequestsDisplayModel>>(LabRequest);

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

        // GET: api/Doctor/{id}
        [HttpGet("Doctor/{id}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetRequestsByDoctorId(string id)
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequestByDoctorId(id);

                var model = _mapper.Map<List<DoctorLabTestRequestsDisplayModel>>(LabRequest);

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

        // POST: api/LabTestRequest 
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNewRequest(TestRequestsViewModel userInput)
        {
            try
            {
                var model = _mapper.Map<LabTestRequestsModel>(userInput);
                model.CreatorID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _labTestRequestsData.AddTestRequests(model);

                return Ok($"lab Request Added to Patient {model.PatientId} ");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/LabTestRequest
        [HttpPut]
        [Authorize(Roles = "LabTester")]
        public IActionResult UpdateRequestResults(LabRequestUpdateViewModel userInput)
        {
            try
            {
                var model = _mapper.Map<LabTestRequestsModel>(userInput);
                model.TesterId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _labTestRequestsData.AddTestResults(model);

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
