using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/PatientProgress")]
    public class PatientProgressController : ApiController
    {
        // GET: api/PatientProgress
        public List<PatientProgressModel> Get()
        {
            PatientProgressData patientProgressData = new PatientProgressData();

            var Progresses = patientProgressData.GetPatientProgresses();

            return Progresses;
        }

        // GET: api/PatientProgress/5
        public List<PatientProgressModel> Get(int id)
        {
            PatientProgressData patientProgressData = new PatientProgressData();

            var Progresses = patientProgressData.GetPatientProgressesById(id);

            return Progresses;
        }

        // GET: api/PatientProgress/?PatientId={patientId}
        public List<PatientProgressModel> GetByPatientID(int patientID)
        {
            PatientProgressData patientProgressData = new PatientProgressData();

            var Progresses = patientProgressData.GetPatientProgressesByPatientID(patientID);

            return Progresses;
        }
        // POST: api/PatientProgress
        public void Post([FromBody] PatientProgressModel patientProgress)
        {
            PatientProgressData patientProgressData = new PatientProgressData();

            patientProgressData.AddProgress(patientProgress);

        }

    }
}
