using ADHApi.Error;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        public AdminController(IArticleData articleData,
            IApiErrorHandler apiErrorHandler,
            AssignedMedicineData assignedMedicineData)
        {
            _articleData = articleData;
            _apiErrorHandler = apiErrorHandler;
            _assignedMedicineData = assignedMedicineData;
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

    }
}
