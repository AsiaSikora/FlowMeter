using System.ComponentModel.DataAnnotations;

namespace FlowMeter.Application.DTOs.Device
{
    public class BaseDeviceDto
    {
        [Required]
        public int DeviceNumber { get; set; }
    }
}
