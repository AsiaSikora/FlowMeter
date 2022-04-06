using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Application.Services.Surveys;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CreateSurvey([FromBody] CreateSurveyDto createSurvey)
        {
            var survey = _service.CreateSurvey(createSurvey);

            return Ok(survey);
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
