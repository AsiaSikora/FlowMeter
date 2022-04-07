using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Application.Services.Surveys;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetSurveys(int userId)
        {
            var surveysDto = await _service.GetSurveys(userId);

            return Ok(surveysDto);
        }

        [HttpGet("{id}", Name = "GetSurvey")]
        public async Task<IActionResult> GetSurvey(int id)
        {
            var surveyDto = await _service.GetSurvey(id);

            return Ok(surveyDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, [FromBody] UpdateSurveyDto updateSurveyDto)
        {
            await _service.UpdateSurvey(id, updateSurveyDto);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyDto createSurvey)
        {
            var survey = await _service.CreateSurvey(createSurvey);

            return Ok(survey);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _service.DeleteSurvey(id);

            return NoContent();
        }

        [HttpGet("last-five-surveys")]
        public async Task<IActionResult> GetLastFiveSurveys(int userId)
        {
            var surveysDto = await _service.GetLastFiveSurveys(userId);

            return Ok(surveysDto);
        }

        [HttpGet("surveys-no-measurements")]
        public async Task<IActionResult> GetAllSurveysWithoutMeasurements(int userId)
        {
            var surveysDto = await _service.GetAllSurveysWithoutMeasurements(userId);

            return Ok(surveysDto);
        }

        [HttpGet("last")]
        public async Task<IActionResult> GetLastSurvey(int userId)
        {
            var surveyDto = await _service.GetLastSurvey(userId);

            return Ok(surveyDto);
        }

    }
}
