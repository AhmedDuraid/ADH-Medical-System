using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientNoteData
    {

        private readonly string ConnectionName = "AHDConnection";
        private readonly IConfiguration _configuration;

        public PatientNoteData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<PatientNoteModel> GetPatienstNotes()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_GetNotes", new { },
                 ConnectionName);

            return output;
        }

        public List<PatientNoteModel> GetPatientsNotesById(int noteId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parameters = new { @NoteId = noteId };

            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_GetNoteById", Parameters,
                 ConnectionName);

            return output;
        }

        public List<PatientNoteModel> GetPatientNotesByPatientId(int patientId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parameters = new { @PatientID = patientId };

            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_GetNoteByPatientID", Parameters,
                 ConnectionName);

            return output;
        }

        public void AddNewPatientNote(PatientNoteModel patientNote)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess(_configuration);

            var Parameters = new
            {
                @PatientID = patientNote.patient_Id,
                @NoteBody = patientNote.note_body,
                @UserID = patientNote.user_ID
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_AddNewNote", Parameters,
                 ConnectionName);
        }
    }
}
