using FlowMeter.Application.DTOs.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.Services.Localizations
{
    public interface ILocalizationsService
    {
        Task<LocalizationDto> CreateLocalization(CreateLocalizationDto createLocalization, int userId);
        Task<IReadOnlyCollection<LocalizationDto>> GetLocalizations(int userId);
    }
}