using System;
using System.Collections.Generic;

namespace MySensors.ApplicationCore.Entities
{
    public class Sensor : BaseEntity<int>
    {
        public string SensorName { get; private set; }
        public int Userid { get; private set; }

        private readonly List<SensorParameter> _sensorParameters = new();
        public IEnumerable<SensorParameter> SensorParameters => _sensorParameters.AsReadOnly();
        
        public void UpdateSensorName(string name)
        {
            if (name.Length is 0 or > 50)
                throw new ArgumentOutOfRangeException(nameof(name));
            SensorName = name;
        }

        public void AddSensorParameter(SensorParameter sensorParameter)
        {
            _sensorParameters.Add(sensorParameter);
        }
        
        public void SetNewUserId(int userId)
        {
            if (userId <= 0)
                throw new ArgumentOutOfRangeException(nameof(userId));
            Userid = userId;
        }
    }
}