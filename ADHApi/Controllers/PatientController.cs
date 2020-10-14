using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PatientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Patient
        [HttpGet]
        public List<PatientModel> Get()
        {
            PatientData patientData = new PatientData();

            var Patients = patientData.GetPatients();

            return Patients;
        }

        // GET: api/Patient/{id}
        [HttpGet("{id}")]
        public List<PatientModel> Get(int id)
        {
            PatientData patientData = new PatientData();

            var Patient = patientData.GetPatientByID(id);

            return Patient;

        }

        // POST: api/Patient
        [HttpPost]
        public void Post([FromBody] PatientModel patient)
        {
            PatientData patientData = new PatientData();

            patientData.AddPatient(patient);
        }
    }
}
