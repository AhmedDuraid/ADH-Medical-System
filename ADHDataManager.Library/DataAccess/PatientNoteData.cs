using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientNoteData : IPatientNoteData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public PatientNoteData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public List<PatientNoteModel> GetNotes()
        {
            var output = _sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindAll", new { });

            return output;
        }

        public List<PatientNoteModel> GetNotesByPatientId(string patientId)
        {
            var Parameters = new { @PatientId = patientId };
            var output = _sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindByPatientId", Parameters);

            return output;
        }

        public List<PatientNoteModel> GetNotesByPatientId_Show(string patientId)
        {
            var Parameters = new { @PatientId = patientId };
            var output = _sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindByPatientId_Show", Parameters);

            return output;
        }
        public List<PatientNoteModel> GetNotesByPatientAndDoctorId(string patientId, string doctorId)
        {
            var Parameters = new { @PatientId = patientId, @DoctortId = doctorId };
            var output = _sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindByPatientIdAndDoctorID", Parameters);

            return output;
        }

        public void AddNewPatientNote(PatientNoteModel patientNote)
        {
            var Parameters = new
            {
                @Id = patientNote.Id,
                @Body = patientNote.Body,
                @PatientId = patientNote.PatientId,
                @AddedBy = patientNote.AddedBy,
                @ShowToPatient = patientNote.ShowToPatient
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_AddNote", Parameters);
        }

        public void DeleteNote(string noteId)
        {
            var Parameters = new { @NoteId = noteId };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_DeleteNoteById", Parameters);
        }

        public void UpdatePatient_PatientAndDoctorId(PatientNoteModel noteModel)
        {
            var Parameters = new
            {
                @PatientId = noteModel.PatientId,
                @DoctortId = noteModel.AddedBy,
                @Body = noteModel.Body,
                @ShowToPatient = noteModel.ShowToPatient
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_UpdatePatientByPatientAndDoctorID", Parameters);
        }

        public void UpdatePatient_PatientId(PatientNoteModel noteModel)
        {
            var Parameters = new
            {
                @PatientId = noteModel.PatientId,
                @Body = noteModel.Body,
                @ShowToPatient = noteModel.ShowToPatient
            };

            _sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_UpdatePatientByPatientID", Parameters);
        }
    }
}
