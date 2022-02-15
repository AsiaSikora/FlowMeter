using System.ComponentModel.DataAnnotations;
using FlowMeter.Domain;


namespace FlowMeter.API.Models.Device
{
    public class BaseDeviceDto
    {
        [Required]
        public int DeviceNumber { get; set; }
        public Domain.User User { get; set; }
    }
}