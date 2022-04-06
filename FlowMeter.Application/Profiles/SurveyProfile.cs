using AutoMapper;
using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Domain;

namespace FlowMeter.Application.Profiles
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
