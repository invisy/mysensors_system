using System.Collections.Generic;

namespace MySensors.ApplicationCore.DTOs
{
    public class SensorRequestAddValuesDTO
    {
        public string Token { get; set; }
        public IEnumerable<SensorParameterWithValueDTO> ParametersWithValues { get; set; }
    }
}