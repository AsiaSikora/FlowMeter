using System;
using System.Collections.Generic;

namespace FlowMeter.Domain
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public HashCode Hash { get; set; }
        public List<Device> ListOfDevices { get; set; }
        public List<Localization> ListOfLocalizations { get; set; }
    }
}