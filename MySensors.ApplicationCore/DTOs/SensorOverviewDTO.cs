using System;
using System.Collections.Generic;

namespace MySensors.ApplicationCore.DTOs
{
    public class SensorOverviewDTO : BaseDTO<int>
    {
        public string SensorName { get; set; }
        public string LastUpdate { get; set; }
        public IEnumerable<SensorOverviewParameterDTO> SensorParameters { get; set; }
    }
}