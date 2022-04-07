using FlowMeter.Application.DTOs.Measurement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.Services.Measurements
{
    public interface IMeasurementsService
    {
        Task<MeasurementDto> CreateMeasurement(CreateMeasurementDto createMeasurement, int surveyId);
        Task DeleteMeasurement(int id);
        Task<MeasurementDto> GetMeasurement(int id);
        Task<IReadOnlyCollection<MeasurementDto>> GetMeasurements(int surveyId);
        Task UpdateMeasurement(int id, UpdateMeasurementDto dto);
    }
}