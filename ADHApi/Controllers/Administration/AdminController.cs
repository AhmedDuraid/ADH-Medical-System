using ADHApi.Error;
using ADHApi.ViewModels;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

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

        public AdminController(IArticleData articleData,
            IApiErrorHandler apiErrorHandler,
            AssignedMedicineData assignedMedicineData,
            AssignedPlanData assignedPlanData,
            IFeedbackData feedbackData,
            ILabTestData labTestData,
            IMapper mapper,
            LabTestRequestsData labTestRequestsData,
            MedicineData medicineData,
            PatientNoteData patientNoteData)
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
        }

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

    }
}
