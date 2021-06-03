using System.Collections.Generic;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.DTOs
{
    public class SensorDTO : BaseDTO<int>
    {
        public string SensorName { get; set; }
        public IEnumerable<SensorParameterDTO> SensorParameters { get; set; }
    }
}