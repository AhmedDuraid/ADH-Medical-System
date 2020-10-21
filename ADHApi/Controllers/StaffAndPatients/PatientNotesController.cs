using ADHApi.Models;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientNotesController : ControllerBase
    {
        private readonly IPatientNoteData _patientNoteData;
        public PatientNotesController(IPatientNoteData patientNoteData)
        {
            _patientNoteData = patientNoteData;
        }

        // GET: api/PatientNotes
        [HttpGet]
        public IActionResult GetNotes()
        {
            var Notes = _patientNoteData.GetNotes();

            if (Notes.Count > 0)
            {
                return Ok(Notes);
            }

            return NotFound();
        }

        // GET: api/PatientNotes/GetNotes/Staff/{patientId}
        [HttpGet("Staff/{patientId}")]
        public IActionResult GetNotes(string patientId)
        {
            var Notes = _patientNoteData.GetNotesByPatientId(patientId);

            if (Notes.Count > 0)
            {
                return Ok(Notes);
            }

            return NotFound();
        }

        // GET: api/PatientNotes/Patient
        [HttpGet("Patient")]
        public IActionResult GetNotesPatient()
        {
            var PatientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Notes = _patientNoteData.GetNotesByPatientId_Show(PatientId);

            if (Notes.Count > 0)
            {
                return Ok(Notes);
            }

            return NotFound();
        }

        // GET: api/PatientNotes/patientId
        [HttpGet("Staff/PatientNote")]
        public IActionResult GetNotesForDoctor([FromQuery] string patientId, [FromQuery] string doctorId)
        {
            var Notes = _patientNoteData.GetNotesByPatientAndDoctorId(patientId, doctorId);

            if (Notes.Count > 0)
            {
                return Ok(Notes);
            }
            return NotFound();
        }

        // POST: api/PatientNotes/
        [HttpPost]
        public IActionResult AddNew([FromBody] ApiPatientNoteModel patientNoteModel)
        {
            var NewNote = new PatientNoteModel()
            {
                AddedBy = patientNoteModel.AddedBy,
                Body = patientNoteModel.Body,
                PatientId = patientNoteModel.PatientId,
                ShowToPatient = patientNoteModel.ShowToPatient
            };
            _patientNoteData.AddNewPatientNote(NewNote);

            return Ok();
        }

        // PUT: api/UpdateNote_PatientDoctor
        [HttpPut("{id}")]
        public IActionResult UpdateNote_PatientDoctor(string id, [FromQuery] string body, [FromQuery] bool show)
        {
            var NewNote = new PatientNoteModel()
            {
                Body = body,
                ShowToPatient = show,
                Id = id
            };
            _patientNoteData.UpdatePatient_PatientAndDoctorId(NewNote);

            return Ok();
        }

        // DELETE: api/PatientNotes/
        [HttpDelete("{noteId}")]
        public IActionResult Delete(string noteId)
        {
            _patientNoteData.DeleteNote(noteId);

            return Ok();
        }
    }
}
