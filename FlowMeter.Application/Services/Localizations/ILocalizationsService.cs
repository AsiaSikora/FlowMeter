using FlowMeter.Application.DTOs.Localization;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Localizations
{
    public interface ILocalizationsService
    {
        LocalizationDto CreateLocalization(CreateLocalizationDto createLocalization, int userId);
        List<LocalizationDto> GetLocalizations(int userId);
    }
}