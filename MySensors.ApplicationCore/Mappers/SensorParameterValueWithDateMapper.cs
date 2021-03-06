using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Mappers
{
    public class SensorParameterValueWithDateMapper : GenericMapper<SensorParameterValue, SensorParameterValueWithDateDTO>
    {
        public override SensorParameterValueWithDateDTO  Map(SensorParameterValue entity)
        {
            SensorParameterValueWithDateDTO dto = new()
            {
                Value = entity.Value,
                UpdateDate = entity.SensorUpdateTime.DateTime.ToString("HH:mm:ss dd/MM/yyyy")
            };

            return dto;
        }
    }
}