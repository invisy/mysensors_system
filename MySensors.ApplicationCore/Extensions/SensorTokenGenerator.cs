using System;

namespace MySensors.ApplicationCore.Extensions
{
    public static class SensorTokenGenerator
    {
        public static string GenerateRandomUniqueToken()
        {
            var ticks = DateTime.Now.Ticks;
            var guid = Guid.NewGuid().ToString();
            return $"{guid}-{ticks}";
        }
    }
}