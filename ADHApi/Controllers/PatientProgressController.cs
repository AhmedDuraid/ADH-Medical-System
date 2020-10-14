using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientProgressController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PatientProgressController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/PatientProgress
        [HttpGet]
        public List<PatientProgressModel> Get()
        {
            PatientProgressData patientProgressData = new PatientProgressData();

            var Progresses = patientProgressData.GetPatientProgresses();

            return Progresses;
        }

        // GET: api/PatientProgress/5
        //[HttpGet("{id}")]
        //public List<PatientProgressModel> Get(int id)
        //{
        //    PatientProgressData patientProgressData = new PatientProgressData(_configuration);

        //    var Progresses = patientProgressData.GetPatientProgressesById(id);

        //    return Progresses;
        //}

        // GET: api/PatientProgress/?PatientId={patientId}

        [HttpGet("{id}")]
        public List<PatientProgressModel> GetByPatientID(int patientID)
        {
            PatientProgressData patientProgressData = new PatientProgressData();

            var Progresses = patientProgressData.GetPatientProgressesByPatientID(patientID);

            return Progresses;
        }

        // POST: api/PatientProgress
        [HttpPost]
        public void Post([FromBody] PatientProgressModel patientProgress)
        {
            PatientProgressData patientProgressData = new PatientProgressData();

            patientProgressData.AddProgress(patientProgress);

        }
    }
}
