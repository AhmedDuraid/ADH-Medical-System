using ADHApi.Error;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ADHApi.Controllers.Registered
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        // TODO
        private readonly IPlanData _planData;
        private readonly IApiErrorHandler _apiErrorHandler;

        public PlanController(IPlanData planData, IApiErrorHandler apiErrorHandler)
        {
            _planData = planData;
            _apiErrorHandler = apiErrorHandler;
        }

        // GET: api/Plan/
        [HttpGet]
        [Authorize(Roles = "Admin, Doctor, Manager")]
        public IActionResult GetPlans()
        {
            try
            {
                List<PlanModel> Plan = _planData.GetPlans();

                if (Plan.Count > 0)
                {
                    return Ok(Plan);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // GET: api/Plan/{type}
        [HttpGet("{type}")]
        [Authorize(Roles = "Admin, Doctor, Manager")]
        public IActionResult GetPlanByType(string type)
        {
            try
            {
                List<PlanModel> Plan = _planData.GetPlansByType(type);

                if (Plan.Count > 0)
                {
                    return Ok(Plan);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // POST: api/Plan/
        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult AddNew([FromBody] PlanModel userInput)
        {
            try
            {
                PlanModel NewPlan = new PlanModel()
                {
                    Type = userInput.Type,
                    Description = userInput.Description,
                    Day1 = userInput.Day1,
                    Day2 = userInput.Day2,
                    Day3 = userInput.Day3,
                    Day4 = userInput.Day4,
                    Day5 = userInput.Day5,
                    Day6 = userInput.Day6,
                    Day7 = userInput.Day7
                };

                _planData.AddPlan(NewPlan);

                return Ok($"Plan added with and have the Id {NewPlan.Id} and type {NewPlan.Type}");
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // PUT: api/Plan
        [HttpPut]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult UpdatePlan([FromBody] PlanModel plan)
        {
            try
            {
                _planData.UpdatePlan(plan);

                return Ok();
            }
            catch (Exception ex)
            {
                _apiErrorHandler.CreateError(ex.Source, ex.StackTrace, ex.Message);
            }

            return StatusCode(500);
        }

        // DELETE: api/Plan/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public IActionResult DeletePlan(string id)
        {
            try
            {
                _planData.DeletePlan(id);

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
