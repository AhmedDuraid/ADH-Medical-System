using ADHDataManager.Library.Internal.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public class PatientNoteData
    {

        private readonly string connectionName = "AHDConnection";
        private readonly string _connectionString;
        private readonly SqlDataAccess sqlDataAccess;

        public PatientNoteData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(connectionName);
            sqlDataAccess = new SqlDataAccess();
        }

        public List<PatientNoteModel> GetNotes()
        {
            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindAll", new { },
                 _connectionString);

            return output;
        }

        public List<PatientNoteModel> GetNotesByPatientId(string patientId)
        {
            var Parameters = new { @PatientId = patientId };
            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindByPatientId", Parameters,
                 _connectionString);

            return output;
        }

        public List<PatientNoteModel> GetNotesByPatientId_Show(string patientId)
        {
            var Parameters = new { @PatientId = patientId };
            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindByPatientId_Show", Parameters,
                 _connectionString);

            return output;
        }
        public List<PatientNoteModel> GetNotesByPatientAndDoctorId(string patientId, string doctorId)
        {
            var Parameters = new { @PatientId = patientId, @DoctortId = doctorId };
            var output = sqlDataAccess.LoadData<PatientNoteModel, dynamic>("dbo.spPatientNote_FindByPatientIdAndDoctorID", Parameters,
                 _connectionString);

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

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_AddNote", Parameters,
                 _connectionString);
        }

        public void DeleteNote(string noteId)
        {
            var Parameters = new { @NoteId = noteId };

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_DeleteNoteById", Parameters,
                 _connectionString);
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

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_UpdatePatientByPatientAndDoctorID", Parameters,
                 _connectionString);
        }

        public void UpdatePatient_PatientId(PatientNoteModel noteModel)
        {
            var Parameters = new
            {
                @PatientId = noteModel.PatientId,
                @Body = noteModel.Body,
                @ShowToPatient = noteModel.ShowToPatient
            };

            sqlDataAccess.SaveData<dynamic>("dbo.spPatientNote_UpdatePatientByPatientID", Parameters,
                 _connectionString);
        }
    }
}
