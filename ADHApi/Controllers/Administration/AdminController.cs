﻿using ADHApi.Error;
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

        public AdminController(IArticleData articleData,
            IApiErrorHandler apiErrorHandler,
            AssignedMedicineData assignedMedicineData,
            AssignedPlanData assignedPlanData,
            IFeedbackData feedbackData,
            ILabTestData labTestData,
            IMapper mapper)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
            _assignedMedicineData = assignedMedicineData;
            _assignedPlanData = assignedPlanData;
            _feedbackData = feedbackData;
            _labTestData = labTestData;
            _mapper = mapper;
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

    }
}
