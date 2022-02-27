using AutoMapper;
using FlowMeter.API.Models.Localization;
using FlowMeter.DataManipulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Controllers
{
    [Route("api/users/{userId}/localizations")]
    [ApiController]
    public class LocalizationsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LocalizationsController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetLocalizations(int userId)
        {
            var localizations = _uow.Localizations.GetLocalizationsForUser(userId);
            var localizationsDto = _mapper.Map<List<LocalizationDto>>(localizations);

            return Ok(localizationsDto);
        }

    }
}
