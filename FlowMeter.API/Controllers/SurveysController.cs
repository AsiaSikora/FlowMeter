using AutoMapper;
using FlowMeter.API.Models.Survey;
using FlowMeter.DataManipulation;
using FlowMeter.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowMeter.DataManipulationInterfaces;
using Microsoft.Extensions.Logging;
using FlowMeter.API.Exceptions;
using FlowMeter.API.Services.Interfaces;

namespace FlowMeter.API.Controllers
{
    [Route("api/users/{userId}/surveys")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveysService _service;

        public SurveysController(ISurveysService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetSurveys(int userId)
        {
            var surveys = _service.GetSurveys(userId);

            return Ok(surveys);
        }

        [HttpGet("{id}", Name = "GetSurvey")]
        public IActionResult GetSurvey(int id)
        {
            var survey = _service.GetSurvey(id);

            return Ok(survey);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSurvey(int id, [FromBody] UpdateSurveyDto updateSurveyDto)
        {
            _service.UpdateSurvey(id, updateSurveyDto);

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateSurvey([FromBody] CreateSurveyDto createSurvey, int userId)
        {
            var survey = _service.CreateSurvey(createSurvey);

            return Ok(survey);
            
            //return Created($"/api/users/{userId}/surveys/{id}", null);
            //return CreatedAtRoute("GetSurvey", new { id = survey.Id }, surveyDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSurvey(int id)
        {
            _service.DeleteSurvey(id);

            return NoContent();
        }

        [HttpGet("last-five-surveys")]
        public IActionResult GetLastFiveSurveys(int userId)
        {
            var surveys = _service.GetLastFiveSurveys(userId);

            return Ok(surveys);
        }
        
        [HttpGet("surveys-no-measurements")]
        public IActionResult GetAllSurveysWithoutMeasurements(int userId)
        {
            var surveys = _service.GetAllSurveysWithoutMeasurements(userId);

            return Ok(surveys);
        }

        [HttpGet("last")]
        public IActionResult GetLastSurvey(int userId)
        {
            var survey = _service.GetLastSurvey(userId);

            return Ok(survey);
        }
        

    }
}
