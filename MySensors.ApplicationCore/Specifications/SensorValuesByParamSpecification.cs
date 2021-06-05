using System;
using System.Linq;
using Ardalis.Specification;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Specifications
{
    public sealed class SensorValuesByParamSpecification : Specification<SensorParameterValue>
    {
        public SensorValuesByParamSpecification(int sensorParamId, int minutes)
        {
            Query.Where(v => v.SensorParameterId == sensorParamId && 
                             v.SensorUpdateTime.DateTime >= DateTime.Now.AddMinutes(-minutes))
                .Include(v => v.SensorUpdateTime);
        }
    }
}