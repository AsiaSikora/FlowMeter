﻿using System;
using System.Collections.Generic;

namespace FlowMeter.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public List<Device> Devices { get; set; }
    }
}