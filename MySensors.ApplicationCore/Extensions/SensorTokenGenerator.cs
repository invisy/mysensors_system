using System;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.ApplicationCore.Extensions
{
    public class SensorTokenGenerator : ISensorTokenGenerator
    {
        public string GenerateRandomUniqueToken()
        {
            var ticks = DateTime.Now.Ticks;
            var guid = Guid.NewGuid().ToString();
            return $"{guid}-{ticks}";
        }
    }
}