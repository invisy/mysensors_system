using Ardalis.Specification;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Specifications
{
    public sealed class SensorParametersSpecification: Specification<SensorParameter>
    {
        public SensorParametersSpecification(string token)
        {
            Query.Where(s => s.Sensor.SensorToken == token)
                .Include(s => s.Sensor);
        }
        
        public SensorParametersSpecification(int id)
        {
            Query.Where(s => s.Sensor.Id == id)
                .Include(s => s.Sensor);
        }
    }
}