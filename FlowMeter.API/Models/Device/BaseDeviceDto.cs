﻿using System.ComponentModel.DataAnnotations;
using FlowMeter.API.Models.User;
using FlowMeter.Domain;


namespace FlowMeter.API.Models.Device
{
    public class BaseDeviceDto
    {
        [Required]
        public int DeviceNumber { get; set; }
        
    }
}