using System.Collections.Generic;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;

namespace MySensors.ApplicationCore.Mappers
{
    public class SensorParameterMapper : GenericMapper<SensorParameter, SensorParameterDTO>
    {
        public override SensorParameter Map(SensorParameterDTO dto)
        {
            SensorParameter entity = new SensorParameter(dto.HumanReadableName, dto.RequestName);

            return entity;
        }
        
        public override SensorParameterDTO  Map(SensorParameter entity)
        {
            SensorParameterDTO dto = new()
            {
                Id = entity.Id,
                HumanReadableName = entity.HumanReadableName,
                RequestName = entity.RequestName
            };

            return dto;
        }
    }
}