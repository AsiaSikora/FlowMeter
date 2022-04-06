using AutoMapper;
using FlowMeter.Application.DTOs.Measurement;
using FlowMeter.Application.Exceptions;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Measurements
{
    public class MeasurementsService : IMeasurementsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasurementsService> _logger;

        public MeasurementsService(IUnitOfWork uow, IMapper mapper, ILogger<MeasurementsService> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public List<MeasurementDto> GetMeasurements(int surveyId)
        {
            var measurements = _uow.Measurements.GetMeasurementsForSurvey(surveyId);
            var measurementsDto = _mapper.Map<List<MeasurementDto>>(measurements);

            return measurementsDto;
        }

        public MeasurementDto GetMeasurement(int id)
        {
            var measurement = _uow.Measurements.Get(x => x.Id == id);

            if (measurement is null)
                throw new NotFoundException("Measurement not found");

            var measurementDto = _mapper.Map<MeasurementDto>(measurement);

            return measurementDto;
        }

        public MeasurementDto CreateMeasurement(CreateMeasurementDto createMeasurement, int surveyId)
        {

            var radius = _uow.Surveys.GetSurveyWithLocalization(surveyId).Localization.CanalRadius;
            var averageFlow = _uow.Measurements.GetAverageFlow(surveyId);
            var currentFlow = MeasurementDto.GetCurrentFlow(createMeasurement, radius);
            var isSpecialPoint = MeasurementDto.CheckIsSpecialPoint(currentFlow, averageFlow);

            var measurementDto = new MeasurementDto()
            {
                Battery = createMeasurement.Battery,
                Pressure = createMeasurement.Pressure,
                Temperature = createMeasurement.Temperature,
                Time = DateTime.Now,
                SurveyId = surveyId,
                CurrentFlow = currentFlow,
                AverageFlow = averageFlow,
                IsSpecialPoint = isSpecialPoint,
            };

            var measurement = _mapper.Map<Measurement>(measurementDto);

            _uow.Measurements.Add(measurement);
            _uow.Save();

            return measurementDto;
        }

        public void UpdateMeasurement(int id, UpdateMeasurementDto dto)
        {
            var measurement = _uow.Measurements.Get(x => x.Id == id);

            if (measurement is null)
                throw new NotFoundException("Measurement not found");

            _mapper.Map(dto, measurement);
            _uow.Measurements.Modify(measurement);
            _uow.Save();
        }

        public void DeleteMeasurement(int id)
        {
            _logger.LogError($"Measurement with id: {id} DELETE action invoked");

            var measurement = _uow.Measurements.Get(x => x.Id == id);

            if (measurement is null)
                throw new NotFoundException("Measurement not found");

            _uow.Measurements.Remove(id);
            _uow.Save();
        }
    }
}
