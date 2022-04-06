using AutoMapper;
using FlowMeter.Application.DTOs.Device;
using FlowMeter.Domain;

namespace FlowMeter.Application.Profiles
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
