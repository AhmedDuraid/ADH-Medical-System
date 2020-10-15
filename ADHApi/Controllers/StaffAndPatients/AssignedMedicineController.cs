using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/staffAndpatients/[controller]/[action]")]
    [ApiController]
    public class AssignedMedicineController : ControllerBase
    {
        private readonly AssignedMedicineData assignedMedicine;
        public AssignedMedicineController(IConfiguration configuration)
        {
            assignedMedicine = new AssignedMedicineData(configuration);

        }

        // GET: api/staffAndpatients/AssignedMedicine/GetAssignedMed
        [HttpGet]
        public List<AssignedMedicineModel> GetAssignedMed()
        {
            var Results = assignedMedicine.GetAssignedMeds();
            return Results;
        }

        // GET: api/staffAndpatients/AssignedMedicine/GetAssignedMedByPatientId/id
        [HttpGet("{patientId}")]
        public List<AssignedMedicineModel> GetAssignedMedByPatientId(string patientId)
        {
            var Results = assignedMedicine.GetAssignedPatientId(patientId);

            return Results;
        }

        // GET: api/staffAndpatients/AssignedMedicine/GetAssignedMedByDoctorId/id
        [HttpGet("{doctorId}")]
        public List<AssignedMedicineModel> GetAssignedMedByDoctorId(string doctorId)
        {
            var Results = assignedMedicine.GetAssignedDoctorId(doctorId);

            return Results;
        }

        // POST: api/staffAndpatients/AssignedMedicine/PostNewAssignedMed
        [HttpPost]
        public void PostNewAssignedMed([FromBody] AssignedMedicineModel model)
        {

            assignedMedicine.AddAssignedMed(model);
        }
    }
}
