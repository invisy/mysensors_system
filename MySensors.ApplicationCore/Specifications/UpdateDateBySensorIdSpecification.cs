using System;
using Ardalis.Specification;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Specifications
{
    public sealed class UpdateDateBySensorIdSpecification: Specification<SensorParameterValue, DateTime>
    {
        public UpdateDateBySensorIdSpecification(int sensorId)
        {
            Query.Select(x => x.SensorUpdateTime.DateTime)
                .Where(x => x.SensorParameter.Sensor.Id == sensorId)
                .Include(x => x.SensorParameter)
                .ThenInclude(x => x.Sensor)
                .Include(x => x.SensorUpdateTime)
                .OrderByDescending(x => x.SensorUpdateTime.DateTime);
        }
    }
}