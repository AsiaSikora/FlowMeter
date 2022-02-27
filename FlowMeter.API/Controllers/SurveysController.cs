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

namespace FlowMeter.API.Controllers
{
    [Route("api/users/{userId}/surveys")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SurveysController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSurveys(int userId)
        {
            var surveys = _uow.Surveys.GetSurveysWithLocalizationDeviceMeasurements(userId);
            var surveysDto = _mapper.Map<List<SurveyDto>>(surveys);

            return Ok(surveysDto);
        }

        [HttpGet("{id}", Name = "GetSurvey")]
        public IActionResult GetSurvey(int id)
        {
            var survey = _uow.Surveys.Get(x => x.Id == id);
            var surveyDto = _mapper.Map<SurveyDto>(survey);

            return Ok(surveyDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSurvey(int id, [FromBody] UpdateSurveyDto updateSurveyDto)
        {
            var survey = _uow.Surveys.Get(x => x.Id == id);

            if (survey == null)
            {
                return NotFound();
            }

            _mapper.Map(updateSurveyDto, survey);
            _uow.Surveys.Modify(survey);
            _uow.Save();

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateSurvey([FromBody] CreateSurveyDto createSurvey)
        {
            var surveyDto = new SurveyDto()
            {
                Date = DateTime.Today,
                DeviceId = createSurvey.DeviceId,
                LocalizationId = createSurvey.LocalizationId,
            };

            var survey = _mapper.Map<Survey>(surveyDto);

            _uow.Surveys.Add(survey);
            _uow.Save();

            return CreatedAtRoute("GetSurvey", new { id = survey.Id }, surveyDto);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSurvey(int id)
        {
            var survey = _uow.Surveys.Get(x => x.Id == id);

            _uow.Surveys.Remove(id);
            _uow.Save();

            return NoContent();
        }

        [HttpGet("last-five-measurements")]
        public IActionResult GetLastFiveSurveys(int userId)
        {
            var surveys = _uow.Surveys.GetLastFiveSurveys(userId);
            var surveysDto = _mapper.Map<List<SurveyDto>>(surveys);

            return Ok(surveysDto);
        }

    }
}
