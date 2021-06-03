using System.Collections.Generic;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.ApplicationCore.Mappers
{
    public class SensorMapper : GenericMapper<Sensor, SensorDTO>
    {
        private readonly IMapper<SensorParameter, SensorParameterDTO> _sensorParametersMapper;
        
        public SensorMapper(IMapper<SensorParameter, SensorParameterDTO> sensorParametersMapper)
        {
            _sensorParametersMapper = sensorParametersMapper;
        }
        
        public override Sensor Map(SensorDTO dto)
        {
            Sensor sensorEntity = new Sensor(dto.SensorName);
            sensorEntity.AddSensorMultipleParameters(_sensorParametersMapper.Map(dto.SensorParameters));
            
            return sensorEntity;
        }
    }
}