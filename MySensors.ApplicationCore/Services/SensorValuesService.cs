using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;
using MySensors.ApplicationCore.Specifications;

namespace MySensors.ApplicationCore.Services
{
    public class SensorValuesService : ISensorValuesService 
    {
        private readonly IUnitOfWork _uow;
        private readonly IAsyncRepository<int, SensorUpdateTime> _sensorUpdateTimeRepository;
        private readonly IAsyncRepository<int, SensorParameter> _sensorParameterRepository;
        private readonly IAsyncRepository<int, SensorParameterValue>  _sensorValueRepository;
        private readonly IMapper<SensorParameterValue, SensorParameterValueWithDateDTO> _mapper;

        public SensorValuesService(IUnitOfWork uow, IMapper<SensorParameterValue, SensorParameterValueWithDateDTO> mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _sensorUpdateTimeRepository = _uow.GetRepository<IAsyncRepository<int, SensorUpdateTime>>();
            _sensorParameterRepository = _uow.GetRepository<IAsyncRepository<int, SensorParameter>>();
            _sensorValueRepository = _uow.GetRepository<IAsyncRepository<int, SensorParameterValue>>();
        }

        public async Task Add(SensorRequestAddValuesDTO dto)
        {
            var spec = new SensorParametersSpecification(dto.Token);
            var sensorParameters = await _sensorParameterRepository.ListAsync(spec);

            if (sensorParameters.Count() == dto.ParametersWithValues.Count())
            {
                var updateTime = new SensorUpdateTime(DateTime.Now);
                await _sensorUpdateTimeRepository.AddAsync(updateTime);
                foreach (var sensorParameterDto in dto.ParametersWithValues)
                {
                    var sensorParameter = sensorParameters.FirstOrDefault(x => x.RequestName == sensorParameterDto.ParameterRequestName);
                    
                    if (sensorParameter != null)
                        sensorParameter.AddSensorParameterValue(new SensorParameterValue(sensorParameterDto.ParameterValue, updateTime));
                    else
                        throw new ArgumentException("Parameter name is invalid");
                }
                await _uow.SaveChanges();
            }
            else
                throw new ArgumentException("Token is invalid");
        }

        public async Task<IEnumerable<SensorParameterValueWithDateDTO>> GetValuesByParamId(int id, int minutes)
        {
            var spec = new SensorValuesByParamSpecification(id, minutes);
            var values = await _sensorValueRepository.ListAsync(spec);
            return _mapper.Map(values);
        }
    }
}