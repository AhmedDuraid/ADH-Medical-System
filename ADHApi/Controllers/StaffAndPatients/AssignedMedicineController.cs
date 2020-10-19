using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ADHApi.Controllers.StaffAndPatients
{
    [Route("api/staffAndpatients/[controller]/[action]")]
    [ApiController]
    public class AssignedMedicineController : ControllerBase
    {
        private readonly IAssignedMedicineData _assignedMedicine;
        public AssignedMedicineController(IAssignedMedicineData assignedMedicineData)
        {
            _assignedMedicine = assignedMedicineData;

        }

        // GET: api/staffAndpatients/AssignedMedicine/GetAssignedMed
        [HttpGet]
        public List<AssignedMedicineModel> GetAssignedMed()
        {
            var Results = _assignedMedicine.GetAssignedMeds();
            return Results;
        }

        // GET: api/staffAndpatients/AssignedMedicine/GetAssignedMedByPatientId/id
        [HttpGet("{patientId}")]
        public List<AssignedMedicineModel> GetAssignedMedByPatientId(string patientId)
        {
            var Results = _assignedMedicine.GetAssignedPatientId(patientId);

            return Results;
        }

        // GET: api/staffAndpatients/AssignedMedicine/GetAssignedMedByDoctorId/id
        [HttpGet("{doctorId}")]
        public List<AssignedMedicineModel> GetAssignedMedByDoctorId(string doctorId)
        {
            var Results = _assignedMedicine.GetAssignedDoctorId(doctorId);

            return Results;
        }

        // POST: api/staffAndpatients/AssignedMedicine/PostNewAssignedMed
        [HttpPost]
        public void PostNewAssignedMed([FromBody] AssignedMedicineModel model)
        {

            _assignedMedicine.AddAssignedMed(model);
        }
    }
}
