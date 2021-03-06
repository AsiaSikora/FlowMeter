using FlowMeter.Application.DTOs.Measurement;
using FlowMeter.Application.Services.Measurements;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowMeter.API.Controllers
{
    [Route("api/surveys/{surveyId}/measurements")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementsService _service;

        public MeasurementsController(IMeasurementsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasurements(int surveyId)
        {
            var measurementsDto = await _service.GetMeasurements(surveyId);

            return Ok(measurementsDto);
        }

        [HttpGet("{id}", Name = "GetMeasurementName")]
        public async Task<IActionResult> GetMeasurement(int id)
        {
            var measurementDto = await _service.GetMeasurement(id);

            return Ok(measurementDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeasurement([FromBody] CreateMeasurementDto createMeasurement, int surveyId)
        {
            var measurementDto = await _service.CreateMeasurement(createMeasurement, surveyId);

            return CreatedAtRoute("GetMeasurementName", new { id = measurementDto.Id, surveyId = surveyId }, measurementDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeasurement(int id, [FromBody] UpdateMeasurementDto dto)
        {
            await _service.UpdateMeasurement(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasurement(int id)
        {
            await _service.DeleteMeasurement(id);

            return NoContent();
        }
    }
}
