using AutoMapper;
using FlowMeter.Application.DTOs.Localization;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.Services.Localizations
{
    public class LocalizationsService : ILocalizationsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LocalizationsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<LocalizationDto>> GetLocalizations(int userId)
        {
            var localizations = await _uow.Localizations.GetLocalizationsForUser(userId);
            var localizationsDto = _mapper.Map<List<LocalizationDto>>(localizations);

            return localizationsDto;
        }

        public async Task<LocalizationDto> CreateLocalization(CreateLocalizationDto createLocalization, int userId)
        {
            var localizationDto = new LocalizationDto()
            {
                Name = createLocalization.Name,
                GpsCoordinate1 = createLocalization.GpsCoordinate1,
                GpsCoordinate2 = createLocalization.GpsCoordinate2,
                CanalRadius = createLocalization.CanalRadius,
                UserId = userId
            };

            var localization = _mapper.Map<Localization>(localizationDto);

            await _uow.Localizations.Add(localization);
            await _uow.Save();

            return localizationDto;
        }
    }
}
