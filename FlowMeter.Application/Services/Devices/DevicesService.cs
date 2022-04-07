using AutoMapper;
using FlowMeter.Application.DTOs.Device;
using FlowMeter.Application.Exceptions;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IReadOnlyCollection<DeviceDto>> GetDevices(int userId)
        {
            var devices = await _uow.Devices.GetAllDevicesWithIncludes(userId);
            var devicesDto = _mapper.Map<List<DeviceDto>>(devices);

            return devicesDto;
        }

        public async Task<DeviceDto> GetDevice(int id)
        {
            var device = await _uow.Devices.Get(x => x.Id == id);

            if (device is null)
                throw new NotFoundException("Device not found");

            var deviceDto = _mapper.Map<DeviceDto>(device);

            return deviceDto;
        }

        public async Task UpdateDevice(int id, UpdateDeviceDto updateDeviceDto)
        {
            var device = await _uow.Devices.Get(x => x.Id == id);

            if (device is null)
                throw new NotFoundException("Device not found");

            _mapper.Map(updateDeviceDto, device);
            await _uow.Devices.Modify(device);
            await _uow.Save();
        }

        public async Task<DeviceDto> CreateDevice(CreateDeviceDto createDevice, int userId)
        {
            var deviceDto = new DeviceDto()
            {
                DeviceNumber = createDevice.DeviceNumber,
                UserId = userId
            };

            var device = _mapper.Map<Device>(deviceDto);

            await _uow.Devices.Add(device);
            await _uow.Save();

            return deviceDto;
        }
    }
}
