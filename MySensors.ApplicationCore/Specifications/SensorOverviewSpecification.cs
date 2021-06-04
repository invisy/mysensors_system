using Ardalis.Specification;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Specifications
{
    public sealed class SensorOverviewSpecification : Specification<Sensor>
    {
        public SensorOverviewSpecification()
        {
            Query.Include(s => s.SensorParameters);
        }
        
        public SensorOverviewSpecification(string id)
        {
            Query.Where(s => s.UserId == id)
                .Include(s => s.SensorParameters);
        }
    }
}