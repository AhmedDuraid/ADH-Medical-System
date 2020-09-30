using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ADHMedicalSystemAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/LabTestRequest")]
    public class LabTestRequestController : ApiController
    {
        // GET: api/LabTestRequest
        public List<LabTestRequestsModel> Get()
        {
            LabTestRequestsData labTestRequests = new LabTestRequestsData();
            var LabRequest = labTestRequests.GetLabTestRequests();
            return LabRequest;
        }

        // GET: api/LabTestRequest/{id}
        public List<LabTestRequestsModel> Get(int id)
        {
            LabTestRequestsData labTestRequests = new LabTestRequestsData();

            var Request = labTestRequests.GetLabTestRequestByID(id);

            return Request;
        }

        // POST: api/LabTestRequest
        public void Post([FromBody] LabTestRequestsModel testRequest)
        {
            LabTestRequestsData labTestRequests = new LabTestRequestsData();

            labTestRequests.AddLabTestRequests(testRequest);

        }
    }
}
