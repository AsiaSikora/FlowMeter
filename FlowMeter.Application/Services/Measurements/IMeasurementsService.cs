using FlowMeter.Application.DTOs.Measurement;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Measurements
{
    public interface IMeasurementsService
    {
        MeasurementDto CreateMeasurement(CreateMeasurementDto createMeasurement, int surveyId);
        void DeleteMeasurement(int id);
        MeasurementDto GetMeasurement(int id);
        List<MeasurementDto> GetMeasurements(int surveyId);
        void UpdateMeasurement(int id, UpdateMeasurementDto dto);
    }
}