using System.Collections.Generic;
using System.Threading.Tasks;
using MySensors.ApplicationCore.DTOs;

namespace MySensors.ApplicationCore.Interfaces
{
    public interface ISensorsService
    {
        Task<IEnumerable<SensorOverviewDTO>> GetSensorsOverview(string userId);
        Task AddSensor(SensorDTO sensor);
        Task ChangeName(int sensorId, string name);
        Task ChangeToken(int id);
        Task RemoveSensor(int id);
        Task<string> GetOwnerUserId(int sensorId);
    }
}