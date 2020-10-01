using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/PatientNote")]
    public class PatientNoteController : ApiController
    {
        // GET: api/PatientNote
        public List<PatientNoteModel> Get()
        {
            PatientNoteData patientNote = new PatientNoteData();

            var Notes = patientNote.GetPatienstNotes();

            return Notes;
        }

        // GET: api/PatientNote/5
        public List<PatientNoteModel> Get(int id)
        {
            PatientNoteData patientNote = new PatientNoteData();

            var Note = patientNote.GetPatientsNotesById(id);

            return Note;

        }

        // GET: api/PatientNote/?patientId = {id}
        public List<PatientNoteModel> GetByPatientID(int patientId)
        {
            PatientNoteData patientNote = new PatientNoteData();

            var Notes = patientNote.GetPatientNotesByPatientId(patientId);


            return Notes;

        }
        // POST: api/PatientNote
        public void Post([FromBody] PatientNoteModel patientNote)
        {
            PatientNoteData patientNoteData = new PatientNoteData();

            patientNoteData.AddNewPatientNote(patientNote);
        }

    }
}
