using FlowMeter.Application.DTOs.Device;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Devices
{
    public interface IDevicesService
    {
        DeviceDto CreateDevice(CreateDeviceDto createDevice, int userId);
        DeviceDto GetDevice(int id);
        List<DeviceDto> GetDevices(int userId);
        void UpdateDevice(int id, UpdateDeviceDto updateDeviceDto);
    }
}