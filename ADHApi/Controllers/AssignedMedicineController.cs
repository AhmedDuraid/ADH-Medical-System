using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedMedicineController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AssignedMedicineController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/AssignedMedicine
        [HttpGet]
        public List<AssignedMedicineModel> Get()
        {
            AssignedMedicineData assignedMedicine = new AssignedMedicineData();

            var Results = assignedMedicine.GetAssignedMeds();

            return Results;
        }

        // GET: api/AssignedMedicine/{id}
        [HttpGet("{id}")]
        public List<AssignedMedicineModel> Get(int id)
        {

            AssignedMedicineData assignedMedicine = new AssignedMedicineData();

            var Results = assignedMedicine.GetAssignedMedByID(id);

            return Results;
        }

        // POST: api/AssignedMedicine
        [HttpPost]
        public void Post([FromBody] AssignedMedicineModel value)
        {
            AssignedMedicineData assignedMedicine = new AssignedMedicineData();

            assignedMedicine.AddAssignedMed(value);
        }
    }
}
