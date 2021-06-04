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

        public SensorParameterValue()
        {
        }
        public SensorParameterValue(double value, SensorUpdateTime sensorUpdateTime)
        {
            SetValue(value);
            SensorUpdateTime = sensorUpdateTime;
        }
        
        public void SetValue(double value)
        {
            if (value > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value));
            Value = value;
        }
    }
}