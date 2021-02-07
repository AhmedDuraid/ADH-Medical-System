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
    [Authorize(Roles = "Doctor")]
    public class PatientNotesController : ControllerBase
    {
        private readonly IPatientNoteData _patientNoteData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly IMapper _mapper;



        public PatientNotesController(IPatientNoteData patientNoteData,
            IApiErrorHandler apiErrorHandler,
            IMapper mapper)
        {
            _patientNoteData = patientNoteData;
            _apiErrorHandler = apiErrorHandler;
            _mapper = mapper;
        }

        // GET: api/PatientNotes/PatientNote/{patientId}
        [HttpGet("PatientNote/{patientId}")]
        public IActionResult GetNotesForDoctor(string patientId)
        {
            try
            {
                string DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                List<PatientNoteModel> Notes = _patientNoteData.GetNotesByPatientAndDoctorId(patientId, DoctorId);

                var model = _mapper.Map<DoctorPatientNoteDisplayModel>(Notes);

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

        // POST: api/PatientNotes/
        [HttpPost]
        public IActionResult AddNew([FromBody] PatientNoteViewModel patientNoteModel)
        {
            try
            {
                var model = _mapper.Map<PatientNoteModel>(patientNoteModel);
                model.AddedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


                _patientNoteData.AddNewPatientNote(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/PatientNotes
        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult UpdateNote_PatientDoctor(string id, [FromBody] UpdatePatientNoteViewModel input)
        {
            // TODO before update, check if the doctor own the note 
            try
            {

                var model = _mapper.Map<PatientNoteModel>(input);
                model.Id = id;

                _patientNoteData.UpdatePatient_PatientAndDoctorId(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/PatientNotes/
        [HttpDelete("{noteId}")]
        public IActionResult Delete(string noteId)
        {
            try
            {
                // TODO before delete, check if the doctor add the note 
                _patientNoteData.DeleteNote(noteId);

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
