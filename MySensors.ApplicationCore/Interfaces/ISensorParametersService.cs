using System.Collections.Generic;
using System.Threading.Tasks;
using MySensors.ApplicationCore.DTOs;

namespace MySensors.ApplicationCore.Interfaces
{
    public interface ISensorParametersService
    {
        Task<IEnumerable<SensorParameterDTO>> GetBySensorId(int id);
    }
}