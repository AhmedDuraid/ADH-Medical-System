using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/StaffAndPatients/[controller]/[action]")]
    [ApiController]
    public class PatientNotesController : ControllerBase
    {
        private readonly IPatientNoteData _patientNoteData;
        public PatientNotesController(IPatientNoteData patientNoteData)
        {
            _patientNoteData = patientNoteData;
        }

        // GET: api/staffAndPatients/PatientNotes/GetNotes
        [HttpGet]
        public IActionResult GetNotes()
        {
            var Notes = _patientNoteData.GetNotes();

            return Ok(Notes);
        }

        // GET: api/staffAndPatients/PatientNotes/GetNotes/patientId
        [HttpGet("{patientId}")]
        public IActionResult GetNotes(string patientId)
        {
            var Notes = _patientNoteData.GetNotesByPatientId(patientId);

            return Ok(Notes);
        }

        // GET: api/staffAndPatients/PatientNotes/GetNotesForPatient/patientId
        [HttpGet("{patientId}")]
        public IActionResult GetNotesForPatient(string patientId)
        {
            var Notes = _patientNoteData.GetNotesByPatientId_Show(patientId);

            return Ok(Notes);
        }

        // GET: api/staffAndPatients/PatientNotes/GetNotesForDoctor/patientId
        [HttpGet("{patientId}/{doctorId}")]
        public IActionResult GetNotesForDoctor(string patientId, string doctorId)
        {
            var Notes = _patientNoteData.GetNotesByPatientAndDoctorId(patientId, doctorId);

            return Ok(Notes);
        }

        // POST: api/staffAndPatients/PatientNotes/AddNew
        [HttpPost]
        public IActionResult AddNew([FromBody] PatientNoteModel patientNoteModel)
        {
            _patientNoteData.AddNewPatientNote(patientNoteModel);

            return Ok();
        }

        // PUT: api/staffAndPatients/UpdateNote_PatientDoctor/AddNew
        [HttpPut]
        public IActionResult UpdateNote_PatientDoctor([FromBody] PatientNoteModel patientNoteModel)
        {
            _patientNoteData.UpdatePatient_PatientAndDoctorId(patientNoteModel);

            return Ok();
        }

        // POST: api/staffAndPatients/UpdateNote/AddNew
        // admin
        [HttpPost]
        public IActionResult UpdateNote([FromBody] PatientNoteModel patientNoteModel)
        {
            _patientNoteData.UpdatePatient_PatientId(patientNoteModel);

            return Ok();
        }

        // DELETE: api/staffAndPatients/PatientNotes/AddNew
        //admin
        [HttpPost("{noteId}")]
        public IActionResult Delete(string noteId)
        {
            _patientNoteData.DeleteNote(noteId);

            return Ok();
        }
    }
}
