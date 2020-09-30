using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AssignedMedicineController : ApiController
    {
        // GET: api/AssignedMedicine
        public List<AssignedMedicineModel> Get()
        {
            AssignedMedicineData assignedMedicine = new AssignedMedicineData();

            var Results = assignedMedicine.GetAssignedMeds();

            return Results;
        }

        // GET: api/AssignedMedicine/{id}
        public List<AssignedMedicineModel> Get(int id)
        {

            AssignedMedicineData assignedMedicine = new AssignedMedicineData();

            var Results = assignedMedicine.GetAssignedMedByID(id);

            return Results;
        }

        // POST: api/AssignedMedicine
        public void Post([FromBody] AssignedMedicineModel value)
        {
            AssignedMedicineData assignedMedicine = new AssignedMedicineData();

            assignedMedicine.AddAssignedMed(value);
        }



    }
}
