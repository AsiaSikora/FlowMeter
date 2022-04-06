using AutoMapper;
using FlowMeter.Application.DTOs.Localization;
using FlowMeter.Domain;

namespace FlowMeter.Application.Profiles
{
    public class LocalizationProfile : Profile
    {
        public LocalizationProfile()
        {
            CreateMap<Localization, LocalizationDto>().ReverseMap();
            CreateMap<Localization, CreateLocalizationDto>().ReverseMap();
            CreateMap<Localization, UpdateLocalizationDto>().ReverseMap();
        }
    }
}
