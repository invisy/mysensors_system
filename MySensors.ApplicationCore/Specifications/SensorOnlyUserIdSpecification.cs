using Ardalis.Specification;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Specifications
{
    public sealed class SensorOnlyUserIdSpecification : Specification<Sensor, string>
    {
        public SensorOnlyUserIdSpecification(int id)
        {
            Query.Select(sensor => sensor.UserId)
                .Where(sensor => sensor.Id == id);
        }
    }
}