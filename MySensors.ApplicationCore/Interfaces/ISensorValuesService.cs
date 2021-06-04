using System.Threading.Tasks;
using MySensors.ApplicationCore.DTOs;

namespace MySensors.ApplicationCore.Interfaces
{
    public interface ISensorValuesService
    {
        Task Add(SensorRequestAddValuesDTO dto);
    }
}