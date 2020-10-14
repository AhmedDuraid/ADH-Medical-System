using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientNotesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PatientNotesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/PatientNote
        [HttpGet]
        public List<PatientNoteModel> Get()
        {
            PatientNoteData patientNote = new PatientNoteData();

            var Notes = patientNote.GetPatienstNotes();

            return Notes;
        }

        // GET: api/PatientNote/5
        //[HttpGet("{id}")]
        //public List<PatientNoteModel> Get(int id)
        //{
        //    PatientNoteData patientNote = new PatientNoteData(_configuration);

        //    var Note = patientNote.GetPatientsNotesById(id);

        //    return Note;

        //}

        // GET: api/PatientNote/?patientId = {id}
        [HttpGet("{id}")]
        public List<PatientNoteModel> GetByPatientID(int patientId)
        {
            PatientNoteData patientNote = new PatientNoteData();

            var Notes = patientNote.GetPatientNotesByPatientId(patientId);


            return Notes;

        }

        // POST: api/PatientNote
        [HttpPost]
        public void Post([FromBody] PatientNoteModel patientNote)
        {
            PatientNoteData patientNoteData = new PatientNoteData();

            patientNoteData.AddNewPatientNote(patientNote);
        }
    }
}
