using AutoMapper;
using FlowMeter.Application.DTOs.Measurement;
using FlowMeter.Domain;

namespace FlowMeter.Application.Profiles
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<Measurement, MeasurementDto>().ReverseMap();
            CreateMap<Measurement, CreateMeasurementDto>().ReverseMap();
            CreateMap<Measurement, UpdateMeasurementDto>().ReverseMap();
        }
    }
}
