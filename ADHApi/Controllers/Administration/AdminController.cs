using ADHApi.CoustomProvider;
using ADHApi.Error;
using ADHApi.ViewModels;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using ADHDataManager.Library.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADHApi.Controllers.Administration
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IArticleData _articleData;
        private readonly IApiErrorHandler _apiErrorHandler;
        private readonly AssignedMedicineData _assignedMedicineData;
        private readonly AssignedPlanData _assignedPlanData;
        private readonly IFeedbackData _feedbackData;
        private readonly ILabTestData _labTestData;
        private readonly IMapper _mapper;
        private readonly LabTestRequestsData _labTestRequestsData;
        private readonly MedicineData _medicineData;
        private readonly PatientNoteData _patientNoteData;
        private readonly UserData _userData;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserRoleData _userRoleData;
        private readonly PatientData _patientData;

        public AdminController(IArticleData articleData,
            IApiErrorHandler apiErrorHandler,
            AssignedMedicineData assignedMedicineData,
            AssignedPlanData assignedPlanData,
            IFeedbackData feedbackData,
            ILabTestData labTestData,
            IMapper mapper,
            LabTestRequestsData labTestRequestsData,
            MedicineData medicineData,
            PatientNoteData patientNoteData,
            UserData userData,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            UserRoleData userRoleData,
            PatientData patientData)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
            _assignedMedicineData = assignedMedicineData;
            _assignedPlanData = assignedPlanData;
            _feedbackData = feedbackData;
            _labTestData = labTestData;
            _mapper = mapper;
            _labTestRequestsData = labTestRequestsData;
            _medicineData = medicineData;
            _patientNoteData = patientNoteData;
            _userData = userData;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRoleData = userRoleData;
            _patientData = patientData;
        }

        // TODO check all methods respons messages 

        // GET api/Admin/Articles
        [HttpGet("Articles")]
        public IActionResult GetArticles()
        {
            try
            {
                List<ArticleModel> articles = _articleData.FindArticles();

                if (articles.Count > 0)
                {
                    return Ok(articles);
                }
                else
                {
                    return NotFound("There is no Articles to show");
                }
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }
            return StatusCode(500);
        }

        // GET api/Admin/Article/{id}
        [HttpGet("Article/{userId}")]
        public IActionResult GetArticlesByUserId(string userId)
        {
            try
            {
                List<ArticleModel> articles = _articleData.FindArticlesByUserId(userId);

                if (articles.Count > 0)
                {
                    return Ok(articles);
                }

                return NotFound($"There is no Article with ID ${userId}");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/AssignedMedicine
        [HttpGet("AssignedMedicine")]
        public IActionResult GetAssignedMed()
        {
            try
            {

                var assignedMedicines = _assignedMedicineData.GetAssignedMeds();

                if (assignedMedicines.Count > 0)
                {
                    return Ok(assignedMedicines);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/AssignedPlan
        [HttpGet("AssignedPlan")]
        public IActionResult GetAssignedPlans()
        {

            try
            {
                var AssignedPlans = _assignedPlanData.GetAssignedPlans();

                if (AssignedPlans.Count > 0)
                {
                    return Ok(AssignedPlans);

                }

                return NotFound("No plans to show");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/Feedback/
        [HttpGet("Feedback")]
        public IActionResult GetFeedbacks()
        {
            try
            {
                List<FeedbackModel> feedbacks = _feedbackData.GetFeedbacks();

                if (feedbacks.Count > 0)
                {
                    return Ok(feedbacks);
                }

                return NotFound("No Feedbacks to show");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/Feedback/new
        [HttpGet("Feedback/new")]
        public IActionResult GetFeedbacksNotReaded()
        {
            try
            {
                var Feedback = _feedbackData.GetFeedbackByNotReaded();

                if (Feedback.Count > 0)
                {
                    return Ok(Feedback);

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Feedback/readerId
        [HttpGet("Feedback/{readerId}")]
        public IActionResult GetFeedbackReaderID(string readerId)
        {
            try
            {
                var Feedback = _feedbackData.GetFeedbackByReaderId(readerId);

                if (Feedback.Count > 0)
                {
                    return Ok(Feedback);

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/LabRequest/doctorname/{id}
        [HttpGet("LabRequest/doctorname/{id}")]
        public IActionResult GetRequestsByDoctorId(string id)
        {
            try
            {
                var LabRequest = _labTestRequestsData.GetTestRequestByDoctorId(id);

                if (LabRequest.Count > 0)
                {
                    return Ok(LabRequest);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/Medicine/
        [HttpGet("Medicines")]
        public IActionResult GetMedicines()
        {
            try
            {
                var Medicines = _medicineData.GetMedicines();

                if (Medicines.Count > 0)
                {
                    return Ok(Medicines);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/Medicine/Name/{MedName}
        [HttpGet("Medicines/Name/{MedName}")]
        public IActionResult GetMedicineByName(string Name)
        {
            var Medicine = _medicineData.GetMedicineByName(Name);

            try
            {
                if (Medicine.Count > 0)
                {
                    return Ok(Medicine);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/PatientNotes
        [HttpGet("PatientNote")]
        public IActionResult GetNotes()
        {
            try
            {
                List<PatientNoteModel> Notes = _patientNoteData.GetNotes();

                if (Notes.Count > 0)
                {
                    return Ok(Notes);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/PatientNotes/{patientId}
        [HttpGet("PatientNote/{patientId}")]
        public IActionResult GetNotes(string patientId)
        {
            try
            {
                List<PatientNoteModel> Notes = _patientNoteData.GetNotesByPatientId(patientId);

                if (Notes.Count > 0)
                {
                    return Ok(Notes);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/Patient
        [HttpGet("Patient")]
        public IActionResult GetPatients()
        {
            try
            {
                var Patients = _patientData.GetPatients();

                if (Patients.Count > 0)
                {
                    return Ok(Patients);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Aadmin/{id}
        [HttpGet("{id}")]
        public IActionResult GetPatientByID(string id)
        {
            try
            {
                var Patient = _patientData.GetPatientByID(id);

                return Ok(Patient);
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Admin/User
        [HttpGet("User")]
        public IActionResult GetUsers()
        {
            try
            {
                List<UserModel> users = _userData.GetUsers();

                if (users.Count > 0)
                {
                    return Ok(users);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);

            }

            return StatusCode(500);

        }

        // GET api/Admin/User/{id}
        [HttpGet("User/{id}")]
        public IActionResult GetUser(string id)
        {
            try
            {
                var user = _userData.GetUserById(id);

                if (user.Count > 0)
                {
                    return Ok(user);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Medicine/
        [HttpPost("Medicines")]
        public IActionResult AddNew([FromBody] MedicineViewModel userInput)
        {
            try
            {

                var model = _mapper.Map<MedicineModel>(userInput);

                _medicineData.AddMedicines(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Admin/LabTest
        [HttpPost("LabTest")]
        public IActionResult AddNewTest(LabTestViewModel input)
        {
            try
            {

                var model = _mapper.Map<LabTestModel>(input);

                _labTestData.AddNewTest(model);

                return Ok("Created");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Admin/Account
        [HttpPost("Account")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterViewModel input)
        {
            try
            {
                // map the input model to ApplicationUserModel
                ApplicationUser model = _mapper.Map<ApplicationUser>(input);

                // Create user 
                IdentityResult result = await _userManager.CreateAsync(model, input.Password);

                if (result.Succeeded)
                {
                    // find if the role is in the database 
                    ApplicationRole RoleInfo = await _roleManager.FindByNameAsync(input.RoleType);

                    if (RoleInfo != null)
                    {
                        // Add the role to database 
                        _userRoleData.AddUserToRole(model.Id, RoleInfo.Id);

                        return Ok($"user {model.UserName} created with {RoleInfo.Name} Role");
                    }

                    return NotFound($"User created, but there is no {input.RoleType} Role. Trt to Add {input.RoleType} and assign it to {model.UserName}");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/Admin/Account/{id}
        [HttpPut("Account/{id}")]
        public IActionResult UpdateUser(string id, [FromBody] AccountViewModel userInput)
        {

            try
            {
                // TODO Check if the ID is in the database before update 
                var model = _mapper.Map<UserModel>(userInput);
                model.Id = id;

                _userData.UpdateUser(model);

                return Ok($"User {id} information Updated ");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/LabTest/Admin/{id}
        [HttpPut("LabTest/{id}")]
        public IActionResult UpdateTest(string id, LabTestViewModel labTestInput)
        {
            try
            {
                var model = _mapper.Map<LabTestModel>(labTestInput);
                model.Id = id;

                _labTestData.UpdateTest(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // Put: api/Feedback
        [HttpPut("Feedback")]
        public IActionResult UpdateFeedback([FromQuery] string feedbackId)
        {
            try
            {
                var readerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                _feedbackData.UpdateFeedbackToReaded(readerId, feedbackId);

                return Ok("Updated");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/Admin/Medicine/{id}
        [HttpPut("Medicine/{id}")]
        public IActionResult UpdateMedicine(string id, [FromBody] MedicineViewModel userInput)
        {
            try
            {
                // TODO Check If there is record before delete 
                var model = _mapper.Map<MedicineModel>(userInput);
                model.Id = id;

                _medicineData.UpdateMed(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/Admin/LabTest/id
        [HttpDelete("LabTest/{id}")]
        public IActionResult DeleteTest(string id)
        {
            try
            {
                // TODO Check if the record is in the database before delete
                _labTestData.DeleteTest(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        [HttpDelete("AssignedMedicine/{id}")]
        public IActionResult DeleteAssignedMedicine(string id)
        {
            try
            {
                var AssignedMed = _assignedMedicineData.GetAssignedById(id);

                if (AssignedMed == null)
                {
                    return NotFound($"There is to Assigned Medicine with this ID {id} ");
                }

                _assignedMedicineData.DeleteAssignedMed(id);

                return Ok($"{id} Deleted");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);

        }

        // DELETE api/Admin/Article/{articleId}
        [HttpDelete("Article/{articleId}")]
        public IActionResult DeleteArticle(string articleId)
        {
            try
            {
                var article = _articleData.FindArticleByID(articleId);

                if (article.Count > 0)
                {
                    return NotFound($"There is no Article with this Id {articleId} ");
                }
                else
                {
                    _articleData.DeleteArticle(articleId);
                    return Ok($"Artilce With Id = {articleId} Deleted");
                }
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);

            }

            return StatusCode(500);
        }

        // DELETE: api/Admin/AssignedPlan/{id}
        [HttpDelete("AssignedPlan/{id}")]
        public IActionResult Delete(string id)
        {
            // TODO     Find the plan before you delete, if the plan in the database do it else return not found
            try
            {
                _assignedPlanData.DeletePlan(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/Admin/LabTestRequest
        [HttpDelete("LabTestRequest/{requestId}")]
        public IActionResult DeleteRequest(string requestId)
        {
            try
            {
                _labTestRequestsData.DeleteRequest(requestId);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/Admin/Medicine/
        [HttpDelete("Medicine/{id}")]
        public IActionResult DeleteMedicine(string id)
        {
            try
            {
                // TODO check if there is records before delete 

                _medicineData.DeleteMed(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/Admin/Account/{id}
        [HttpDelete("Account/{id}")]
        public IActionResult DeleteUser(string id)
        {
            // TODO Check if the user in the database before delete 
            try
            {
                _userData.DeleteUser(id);

                return Ok($"user {id} Deleted");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

    }

}

