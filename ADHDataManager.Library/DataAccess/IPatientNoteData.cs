using ADHDataManager.Library.Models;
using System.Collections.Generic;

namespace ADHDataManager.Library.DataAccess
{
    public interface IPatientNoteData
    {
        void AddNewPatientNote(PatientNoteModel patientNote);
        void DeleteNote(string noteId);
        List<PatientNoteModel> GetNotes();
        List<PatientNoteModel> GetNotesByPatientAndDoctorId(string patientId, string doctorId);
        List<PatientNoteModel> GetNotesByPatientId(string patientId);
        List<PatientNoteModel> GetNotesByPatientId_Show(string patientId);
        void UpdatePatient_PatientAndDoctorId(PatientNoteModel noteModel);
    }
}