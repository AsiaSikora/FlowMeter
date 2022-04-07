using FlowMeter.Application.DTOs.Device;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.Services.Devices
{
    public interface IDevicesService
    {
        Task<DeviceDto> CreateDevice(CreateDeviceDto createDevice, int userId);
        Task<DeviceDto> GetDevice(int id);
        Task<IReadOnlyCollection<DeviceDto>> GetDevices(int userId);
        Task UpdateDevice(int id, UpdateDeviceDto updateDeviceDto);
    }
}