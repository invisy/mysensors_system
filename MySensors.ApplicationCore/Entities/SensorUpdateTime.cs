using System;

namespace MySensors.ApplicationCore.Entities
{
    public class SensorUpdateTime : BaseEntity<int>
    {
        public DateTime DateTime { get; private set; }

        public SensorUpdateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }
    }
}