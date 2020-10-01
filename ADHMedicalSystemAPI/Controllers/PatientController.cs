using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Patient")]
    public class PatientController : ApiController
    {
        // GET: api/Patient
        public List<PatientModel> Get()
        {
            PatientData patientData = new PatientData();

            var Patients = patientData.GetPatients();

            return Patients;
        }

        // GET: api/Patient/{id}
        public List<PatientModel> Get(int id)
        {
            PatientData patientData = new PatientData();

            var Patient = patientData.GetPatientByID(id);

            return Patient;

        }

        // POST: api/Patient
        public void Post([FromBody] PatientModel patient)
        {
            PatientData patientData = new PatientData();

            patientData.AddPatient(patient);
        }


    }
}
