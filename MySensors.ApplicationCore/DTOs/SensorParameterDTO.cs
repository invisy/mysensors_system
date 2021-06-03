namespace MySensors.ApplicationCore.DTOs
{
    public class SensorParameterDTO : BaseDTO<int>
    {
        public string HumanReadableName { get; set; }
        public string RequestName { get; set; }
    }
}