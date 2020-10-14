using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MedicineController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Medicine
        [HttpGet]
        public List<MedicineModel> Get()
        {
            MedicineData medicineData = new MedicineData();

            var Medicines = medicineData.GetMedicines();

            return Medicines;
        }

        // GET: api/Medicine/{id}
        [HttpGet("{id}")]
        public List<MedicineModel> Get(int id)
        {
            MedicineData medicineData = new MedicineData();

            var Medicine = medicineData.GetMedicineByID(id);

            return Medicine;
        }

        // GET: api/Medicine/5
        [HttpGet("{name}")]
        public List<MedicineModel> Get(string medName)
        {
            MedicineData medicineData = new MedicineData();

            var Medicine = medicineData.GetMedicineByName(medName);

            return Medicine;
        }

        // POST: api/Medicine
        [HttpPost]
        public void Post([FromBody] MedicineModel medicine)
        {
            MedicineData medicineData = new MedicineData();

            medicineData.AddMedicines(medicine);
        }
    }
}
