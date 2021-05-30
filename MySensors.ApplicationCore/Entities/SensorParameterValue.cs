using System;
using System.Reflection.Metadata;

namespace MySensors.ApplicationCore.Entities
{
    public class SensorParameterValue : BaseEntity<int>
    {
        public SensorParameter SensorParameter { get; private set; }
        public int SensorParameterId { get; private set; }
        public double Value { get; private set; }
        public SensorUpdateTime SensorUpdateTime { get; private set; }
        public int SensorUpdateTimeId { get; private set; }

        public SensorParameterValue(double value, int sensorUpdateTimeId)
        {
            SetValue(value);
            SetSensorUpdateTimeId(sensorUpdateTimeId);
        }
        
        public void SetValue(double value)
        {
            if (value > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value));
            Value = value;
        }

        public void SetSensorUpdateTimeId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));
            SensorUpdateTimeId = id;
        }
    }
}