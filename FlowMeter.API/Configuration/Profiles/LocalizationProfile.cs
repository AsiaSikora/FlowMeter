using AutoMapper;
using FlowMeter.API.Models.Localization;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Configuration.Profiles
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
