using FlowMeter.Application.DTOs.Localization;
using FlowMeter.Application.Services.Localizations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetLocalizations(int userId)
        {
            var localizations = await _service.GetLocalizations(userId);

            return Ok(localizations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocalization([FromBody] CreateLocalizationDto createLocalization, int userId)
        {
            var localizationDto = await _service.CreateLocalization(createLocalization, userId);

            return CreatedAtRoute("Get", new { id = localizationDto.Id }, localizationDto);

        }

    }
}
