using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.ApplicationCore.Entities
{
    public class Sensor : BaseEntity<int>
    {
        public string SensorName { get; private set; }
        public string SensorToken { get; private set; }
        public string Userid { get; private set; }

        private readonly List<SensorParameter> _sensorParameters = new();
        public IEnumerable<SensorParameter> SensorParameters => _sensorParameters.AsReadOnly();

        public Sensor(string sensorName)
        {
            UpdateSensorName(sensorName);
            
        }
        
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
        
        public void AddSensorMultipleParameters(IEnumerable<SensorParameter> sensorParameters)
        {
            _sensorParameters.AddRange(sensorParameters);
        }
        
        public void SetNewUserId(string userId)
        {
            if (userId.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(userId));
            Userid = userId;
        }
        
        public void SetNewToken(string token)
        {
            if (token.Length == 0)
                throw new ArgumentNullException(nameof(token));
            SensorToken = token;
        }
    }
}