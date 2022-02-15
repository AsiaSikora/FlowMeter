using AutoMapper;
using FlowMeter.API.Models.Device;
using FlowMeter.Domain;

namespace FlowMeter.API.Configuration.Profiles
{
    public class DeviceProfile : Profile    
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<Device, CreateDeviceDto>().ReverseMap();
            CreateMap<Device, UpdateDeviceDto>().ReverseMap();
        }
    }
}