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
            var surveysDto = _service.GetSurveys(userId);

            return Ok(surveysDto);
        }

        [HttpGet("{id}", Name = "GetSurvey")]
        public IActionResult GetSurvey(int id)
        {
            var surveyDto = _service.GetSurvey(id);

            return Ok(surveyDto);
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
            var surveysDto = _service.GetLastFiveSurveys(userId);

            return Ok(surveysDto);
        }

        [HttpGet("surveys-no-measurements")]
        public IActionResult GetAllSurveysWithoutMeasurements(int userId)
        {
            var surveysDto = _service.GetAllSurveysWithoutMeasurements(userId);

            return Ok(surveysDto);
        }

        [HttpGet("last")]
        public IActionResult GetLastSurvey(int userId)
        {
            var surveyDto = _service.GetLastSurvey(userId);

            return Ok(surveyDto);
        }

    }
}
