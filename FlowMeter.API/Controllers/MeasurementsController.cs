using FlowMeter.Application.DTOs.Measurement;
using FlowMeter.Application.Services.Measurements;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetMeasurements(int surveyId)
        {
            var measurementsDto = _service.GetMeasurements(surveyId);

            return Ok(measurementsDto);
        }

        [HttpGet("{id}", Name = "GetMeasurementName")]
        public IActionResult GetMeasurement(int id)
        {
            var measurementDto = _service.GetMeasurement(id);

            return Ok(measurementDto);
        }

        [HttpPost]
        public IActionResult CreateMeasurement([FromBody] CreateMeasurementDto createMeasurement, int surveyId)
        {
            var measurementDto = _service.CreateMeasurement(createMeasurement, surveyId);

            return CreatedAtRoute("GetMeasurementName", new { id = measurementDto.Id, surveyId = surveyId }, measurementDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeasurement(int id, [FromBody] UpdateMeasurementDto dto)
        {
            _service.UpdateMeasurement(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeasurement(int id)
        {
            _service.DeleteMeasurement(id);

            return NoContent();
        }
    }
}
