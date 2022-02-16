using AutoMapper;
using FlowMeter.API.Models.Survey;
using FlowMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Configuration.Profiles
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<Survey, SurveyDto>().ReverseMap();
            CreateMap<Survey, CreateSurveyDto>().ReverseMap();
            CreateMap<Survey, UpdateSurveyDto>().ReverseMap();
        }
    }
}
