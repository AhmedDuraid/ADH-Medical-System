using ADHApi.Error;
using ADHApi.Models.PatientNotes;
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
    public class PatientNotesController : ControllerBase
    {
        private readonly IPatientNoteData _patientNoteData;
        private readonly IApiErrorHandler _apiErrorHandler;

        // TODO before update patient note, check if the token doctor is the same doctor in note  "PHASE 3"
        // TODO before DELETE, check who delete note his id in the row. if not he can't delete ""PHASE 3"

        public PatientNotesController(IPatientNoteData patientNoteData, IApiErrorHandler apiErrorHandler)
        {
            _patientNoteData = patientNoteData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/PatientNotes
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetNotes()
        {
            try
            {
                List<PatientNoteModel> Notes = _patientNoteData.GetNotes();

                if (Notes.Count > 0)
                {
                    return Ok(Notes);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/PatientNotes/Staff/{patientId}
        [HttpGet("Staff/{patientId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetNotes(string patientId)
        {
            try
            {
                List<PatientNoteModel> Notes = _patientNoteData.GetNotesByPatientId(patientId);

                if (Notes.Count > 0)
                {
                    return Ok(Notes);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/PatientNotes/Patient
        [HttpGet("Patient")]
        [Authorize(Roles = "Patient")]
        public IActionResult GetNotesPatient()
        {
            try
            {
                string PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                List<PatientNoteModel> Notes = _patientNoteData.GetNotesByPatientId_Show(PatientId);

                if (Notes.Count > 0)
                {
                    return Ok(Notes);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/PatientNotes/Doctor/PatientNote/{patientId}
        [HttpGet("Doctor/PatientNote/{patientId}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult GetNotesForDoctor(string patientId)
        {
            try
            {
                string DoctorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                List<PatientNoteModel> Notes = _patientNoteData.GetNotesByPatientAndDoctorId(patientId, DoctorId);

                if (Notes.Count > 0)
                {
                    return Ok(Notes);
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
        [Authorize(Roles = "Doctor")]
        public IActionResult AddNew([FromBody] ApiAddPatientNoteModel patientNoteModel)
        {
            try
            {
                var NewNote = new PatientNoteModel()
                {
                    AddedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    Body = patientNoteModel.Body,
                    PatientId = patientNoteModel.PatientId,
                    ShowToPatient = patientNoteModel.ShowToPatient
                };

                _patientNoteData.AddNewPatientNote(NewNote);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/UpdateNote_PatientDoctor
        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult UpdateNote_PatientDoctor(string id, [FromBody] ApiUpdatePatientNoteModel input)
        {

            try
            {
                var NewNote = new PatientNoteModel()
                {
                    Body = input.Body,
                    ShowToPatient = input.ShowToPatient,
                    Id = id
                };
                _patientNoteData.UpdatePatient_PatientAndDoctorId(NewNote);

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
