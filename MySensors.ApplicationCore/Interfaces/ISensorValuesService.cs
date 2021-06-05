using System.Collections.Generic;
using System.Threading.Tasks;
using MySensors.ApplicationCore.DTOs;

namespace MySensors.ApplicationCore.Interfaces
{
    public interface ISensorValuesService
    {
        Task Add(SensorRequestAddValuesDTO dto);
        Task<IEnumerable<SensorParameterValueWithDateDTO>> GetValuesByParamId(int id, int minutes);
    }
}