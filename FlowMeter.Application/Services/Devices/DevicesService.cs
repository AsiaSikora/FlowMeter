using AutoMapper;
using FlowMeter.Application.DTOs.Device;
using FlowMeter.Application.Exceptions;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Domain;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Devices
{
    public class DevicesService : IDevicesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DevicesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public List<DeviceDto> GetDevices(int userId)
        {
            var devices = _uow.Devices.GetAllDevicesWithIncludes(userId);
            var devicesDto = _mapper.Map<List<DeviceDto>>(devices);

            return devicesDto;
        }

        public DeviceDto GetDevice(int id)
        {
            var device = _uow.Devices.Get(x => x.Id == id);

            if (device is null)
                throw new NotFoundException("Device not found");

            var deviceDto = _mapper.Map<DeviceDto>(device);

            return deviceDto;
        }

        public void UpdateDevice(int id, UpdateDeviceDto updateDeviceDto)
        {
            var device = _uow.Devices.Get(x => x.Id == id);

            if (device is null)
                throw new NotFoundException("Device not found");

            _mapper.Map(updateDeviceDto, device);
            _uow.Devices.Modify(device);
            _uow.Save();
        }

        public DeviceDto CreateDevice(CreateDeviceDto createDevice, int userId)
        {
            var deviceDto = new DeviceDto()
            {
                DeviceNumber = createDevice.DeviceNumber,
                UserId = userId
            };

            var device = _mapper.Map<Device>(deviceDto);

            _uow.Devices.Add(device);
            _uow.Save();

            return deviceDto;
        }
    }
}
