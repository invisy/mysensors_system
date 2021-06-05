using Ardalis.Specification;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Specifications
{
    public sealed class SensorOnlyTokenSpecification : Specification<Sensor, string>
    {
        public SensorOnlyTokenSpecification(int id)
        {
            Query.Select(sensor => sensor.SensorToken)
                .Where(sensor => sensor.Id == id);
        }
    }
}