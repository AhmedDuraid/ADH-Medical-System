using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ADHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestRequestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LabTestRequestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/LabTestRequest
        [HttpGet]
        public List<LabTestRequestsModel> Get()
        {
            LabTestRequestsData labTestRequests = new LabTestRequestsData();
            var LabRequest = labTestRequests.GetLabTestRequests();
            return LabRequest;
        }

        // GET: api/LabTestRequest/{id}
        [HttpGet("{name}")]
        public List<LabTestRequestsModel> Get(int id)
        {
            LabTestRequestsData labTestRequests = new LabTestRequestsData();

            var Request = labTestRequests.GetLabTestRequestByID(id);

            return Request;
        }

        // POST: api/LabTestRequest
        [HttpPost]
        public void Post([FromBody] LabTestRequestsModel testRequest)
        {
            LabTestRequestsData labTestRequests = new LabTestRequestsData();

            labTestRequests.AddLabTestRequests(testRequest);

        }
    }
}
