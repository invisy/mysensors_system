using System;
using System.Collections.Generic;
using System.Linq;
using MySensors.ApplicationCore.Exceptions;

namespace MySensors.ApplicationCore.Entities
{
    public class SensorParameter : BaseEntity<int>
    {
        public string HumanReadableName { get; private set; }
        public string RequestName { get; private set; }
        public int SensorId { get; private set; }
        
        private readonly List<SensorParameterValue> _sensorParameterValues = new();
        public IEnumerable<SensorParameterValue> SensorParameterValues => _sensorParameterValues.AsReadOnly();

        public SensorParameter(string humanReadableName, string requestName, IEnumerable<SensorParameterValue> values)
        {
            UpdateHumanReadableName(humanReadableName);
            UpdateRequestName(requestName);
            _sensorParameterValues = values.ToList();
        }
        
        public void UpdateHumanReadableName(string name)
        {
            if (name.Length is 0 or > 50)
                throw new ArgumentOutOfRangeException(nameof(name));
            HumanReadableName = name;
        }
        
        public void UpdateRequestName(string name)
        {
            if (name.Length is 0 or > 25)
                throw new ArgumentOutOfRangeException(nameof(name));
            RequestName = name;
        }
        
        public void AddSensorParameter(SensorParameterValue sensorParameterValue)
        {
            _sensorParameterValues.Add(sensorParameterValue);
        }
    }
}