using System.Linq;
using Ardalis.Specification;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Specifications
{
    public sealed class SensorParamLastValueSpecification : Specification<SensorParameterValue>
    {
        public SensorParamLastValueSpecification(int sensorParamId)
        {
            Query.Where(v => v.SensorParameterId == sensorParamId)
                .OrderByDescending(v => v.SensorUpdateTime);
        }
    }
}