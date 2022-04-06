using AutoMapper;
using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Application.Exceptions;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Surveys
{
    public class SurveysService : ISurveysService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<SurveysService> _logger;

        public SurveysService(IUnitOfWork uow, IMapper mapper, ILogger<SurveysService> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public List<SurveyDto> GetSurveys(int userId)
        {
            var surveys = _uow.Surveys.GetSurveysWithLocalizationDeviceMeasurements(userId);
            var surveysDto = _mapper.Map<List<SurveyDto>>(surveys);

            return surveysDto;
        }

        public SurveyDto GetSurvey(int id)
        {
            var survey = _uow.Surveys.GetSurveyWithIncludes(id);

            if (survey is null)
                throw new NotFoundException("Survey not found");

            var surveyDto = _mapper.Map<SurveyDto>(survey);

            return surveyDto;
        }

        public void UpdateSurvey(int id, UpdateSurveyDto updateSurveyDto)
        {
            var survey = _uow.Surveys.Get(x => x.Id == id);

            if (survey is null)
                throw new NotFoundException("Survey not found");

            _mapper.Map(updateSurveyDto, survey);
            _uow.Surveys.Modify(survey);
            _uow.Save();
        }

        public Survey CreateSurvey(CreateSurveyDto createSurvey)
        {
            var surveyDto = new SurveyDto()
            {
                Date = DateTime.Now,
                DeviceId = createSurvey.DeviceId,
                LocalizationId = createSurvey.LocalizationId,
            };

            var survey = _mapper.Map<Survey>(surveyDto);

            _uow.Surveys.Add(survey);
            _uow.Save();

            return survey;
        }

        public void DeleteSurvey(int id)
        {
            _logger.LogError($"Survey with id: {id} DELETE action invoked");

            var survey = _uow.Surveys.Get(x => x.Id == id);

            if (survey is null)
                throw new NotFoundException("Survey not found");

            _uow.Surveys.Remove(id);
            _uow.Save();
        }

        public List<SurveyDto> GetLastFiveSurveys(int userId)
        {
            var surveys = _uow.Surveys.GetLastFiveSurveys(userId);

            var surveysDto = _mapper.Map<List<SurveyDto>>(surveys);

            return surveysDto;
        }

        public List<SurveyDto> GetAllSurveysWithoutMeasurements(int userId)
        {
            var surveys = _uow.Surveys.GetAllSurveysWithoutMeasurements(userId);
            var surveysDto = _mapper.Map<List<SurveyDto>>(surveys);

            return surveysDto;
        }

        public SurveyDto GetLastSurvey(int userId)
        {
            var survey = _uow.Surveys.GetLastSurvey(userId);
            if (survey is null)
                throw new NotFoundException("Survey not found");

            var surveyDto = _mapper.Map<SurveyDto>(survey);

            return surveyDto;
        }
    }
}
