using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedPlanController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AssignedPlanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/AssignedPlan
        [HttpGet]
        public List<AssignedPlanModel> Get()
        {
            AssignedPlanData assignedPlanData = new AssignedPlanData();

            var AssignedPlans = assignedPlanData.GetAssignedPlans();

            return AssignedPlans;
        }

        // GET: api/AssignedPlan/5
        [HttpGet("{id}")]
        public List<AssignedPlanModel> GetByPatientID(int patientId)
        {
            AssignedPlanData assignedPlanData = new AssignedPlanData();

            var AssignedPlans = assignedPlanData.GetAssignedPlansByPaitnetID(patientId);

            return AssignedPlans;
        }

        // POST: api/AssignedPlan
        [HttpPost]
        public void Post([FromBody] AssignedPlanModel assigned)
        {
            AssignedPlanData assignedPlanData = new AssignedPlanData();

            assignedPlanData.AddAssignedPlan(assigned);


        }
    }
}
