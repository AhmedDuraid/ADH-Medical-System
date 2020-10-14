using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientNoteData
    {

        private readonly string ConnectionName = "AHDConnection";


        public List<PatientNoteModel> GetPatienstNotes()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_GetNotes", new { },
                 ConnectionName);

            return output;
        }

        public List<PatientNoteModel> GetPatientsNotesById(int noteId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new { @NoteId = noteId };

            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_GetNoteById", Parameters,
                 ConnectionName);

            return output;
        }

        public List<PatientNoteModel> GetPatientNotesByPatientId(int patientId)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new { @PatientID = patientId };

            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_GetNoteByPatientID", Parameters,
                 ConnectionName);

            return output;
        }

        public void AddNewPatientNote(PatientNoteModel patientNote)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

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
