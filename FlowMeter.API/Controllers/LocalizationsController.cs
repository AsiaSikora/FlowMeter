using FlowMeter.Application.DTOs.Localization;
using FlowMeter.Application.Services.Localizations;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeter.API.Controllers
{
    [Route("api/users/{userId}/localizations")]
    [ApiController]
    public class LocalizationsController : ControllerBase
    {
        private readonly ILocalizationsService _service;

        public LocalizationsController(ILocalizationsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetLocalizations(int userId)
        {
            var localizations = _service.GetLocalizations(userId);

            return Ok(localizations);
        }

        [HttpPost]
        public IActionResult CreateLocalization([FromBody] CreateLocalizationDto createLocalization, int userId)
        {
            var localizationDto = _service.CreateLocalization(createLocalization, userId);

            return CreatedAtRoute("Get", new { id = localizationDto.Id }, localizationDto);

        }

    }
}
