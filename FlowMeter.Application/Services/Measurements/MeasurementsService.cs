using AutoMapper;
using FlowMeter.Application.DTOs.Measurement;
using FlowMeter.Application.Exceptions;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IReadOnlyCollection<MeasurementDto>> GetMeasurements(int surveyId)
        {
            var measurements = await _uow.Measurements.GetMeasurementsForSurvey(surveyId);
            var measurementsDto = _mapper.Map<List<MeasurementDto>>(measurements);

            return measurementsDto;
        }

        public async Task<MeasurementDto> GetMeasurement(int id)
        {
            var measurement = await _uow.Measurements.Get(x => x.Id == id);

            if (measurement is null)
                throw new NotFoundException("Measurement not found");

            var measurementDto = _mapper.Map<MeasurementDto>(measurement);

            return measurementDto;
        }

        public async Task<MeasurementDto> CreateMeasurement(CreateMeasurementDto createMeasurement, int surveyId)
        {

            var survey = await _uow.Surveys.GetSurveyWithLocalization(surveyId);
            var radius = survey.Localization.CanalRadius;
            var averageFlow = await _uow.Measurements.GetAverageFlow(surveyId);
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

            await _uow.Measurements.Add(measurement);
            await _uow.Save();

            return measurementDto;
        }

        public async Task UpdateMeasurement(int id, UpdateMeasurementDto dto)
        {
            var measurement = await _uow.Measurements.Get(x => x.Id == id);

            if (measurement is null)
                throw new NotFoundException("Measurement not found");

            _mapper.Map(dto, measurement);
            await _uow.Measurements.Modify(measurement);
            await _uow.Save();
        }

        public async Task DeleteMeasurement(int id)
        {
            _logger.LogError($"Measurement with id: {id} DELETE action invoked");

            var measurement = await _uow.Measurements.Get(x => x.Id == id);

            if (measurement is null)
                throw new NotFoundException("Measurement not found");

            await _uow.Measurements.Remove(id);
            await _uow.Save();
        }
    }
}
