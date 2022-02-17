using AutoMapper;
using FlowMeter.API.Models.Measurement;
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
    [Route("api/surveys/{surveyId}/measurements")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MeasurementsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMeasurements(int surveyId)
        {
            var measurements = _uow.Measurements.GetMeasurementsForSurvey(surveyId);
            var measurementsDto = _mapper.Map<List<MeasurementDto>>(measurements);

            return Ok(measurementsDto);
        }

        [HttpGet("{id}", Name = "GetMeasurement")]
        public IActionResult GetMeasurement(int id, int surveyId)
        {
            var measurement = _uow.Measurements.Get(x => x.Id == id);
            var measurementDto = _mapper.Map<MeasurementDto>(measurement);

            return Ok(measurementDto);
        }

        [HttpPost]
        public IActionResult CreateMeasurement([FromBody] CreateMeasurementDto dto, int surveyId)
        {

            var radius = _uow.Measurements.GetMeasurementSurvey(surveyId).Localization.CanalRadius;
            var averageFlow = _uow.Measurements.GetAverageFlow(surveyId);
            
            var measurementDto = new MeasurementDto(dto, surveyId, radius, averageFlow);


            var measurement = _mapper.Map<Measurement>(measurementDto);

            _uow.Measurements.Add(measurement);
            _uow.Save();

            return CreatedAtRoute("GetMeasurement", new { id = measurementDto.Id }, measurementDto);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeasurement(int id, [FromBody] UpdateMeasurementDto dto)
        {
            var measurement = _uow.Measurements.Get(x => x.Id == id);

            if (measurement == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, measurement);
            _uow.Measurements.Modify(measurement);
            _uow.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeasurement(int id, int surveyId)
        {
            var measurement = _uow.Measurements.Get(x => x.Id == id);

            _uow.Measurements.Remove(id);
            _uow.Save();

            return NoContent();
        }
    }
}
