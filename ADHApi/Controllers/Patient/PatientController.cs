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
        private readonly PatientNoteData _patientNoteData;
        private readonly PatientData _patientData;
        private readonly UserData _userData;

        public PatientController(LabTestRequestsData labTestRequestsData,
            ApiErrorHandler apiErrorHandler,
            IMapper mapper,
            PatientNoteData patientNoteData,
            PatientData patientData,
            UserData userData)
        {
            _labTestRequestsData = labTestRequestsData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
            _patientNoteData = patientNoteData;
            _patientData = patientData;
            _userData = userData;
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

        // GET: api/Patient/PatientNotes
        [HttpGet("PatientNote")]
        public IActionResult GetNotesPatient()
        {
            try
            {
                string PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                List<PatientNoteModel> Notes = _patientNoteData.GetNotesByPatientId_Show(PatientId);

                var model = _mapper.Map<List<PatientNoteModel>>(Notes);

                if (Notes.Count > 0)
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

        // GET: api/Patient
        [HttpGet("Patient")]
        public IActionResult GetPatientByID()
        {
            try
            {
                var PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var Patient = _patientData.GetPatientByID(PatientId);

                if (Patient.Count > 0)
                {
                    return Ok(Patient);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        [HttpPut("Patient")]
        public IActionResult UpdatePatient([FromBody] AccountViewModel userInput)
        {
            try
            {

                string UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var model = _mapper.Map<UserModel>(userInput);
                model.Id = UserId;

                _userData.UpdateUser(model);

                return Ok($"{UserId} information Updated ");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);

        }
    }
}
