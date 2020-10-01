using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    public class AssignedPlanController : ApiController
    {
        // GET: api/AssignedPlan
        public List<AssignedPlanModel> Get()
        {
            AssignedPlanData assignedPlanData = new AssignedPlanData();

            var AssignedPlans = assignedPlanData.GetAssignedPlans();

            return AssignedPlans;
        }

        // GET: api/AssignedPlan/5
        public List<AssignedPlanModel> GetByPatientID(int patientId)
        {
            AssignedPlanData assignedPlanData = new AssignedPlanData();

            var AssignedPlans = assignedPlanData.GetAssignedPlansByPaitnetID(patientId);

            return AssignedPlans;
        }

        // POST: api/AssignedPlan
        public void Post([FromBody] AssignedPlanModel assigned)
        {
            AssignedPlanData assignedPlanData = new AssignedPlanData();

            assignedPlanData.AddAssignedPlan(assigned);


        }


    }
}
