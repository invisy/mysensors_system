using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Exceptions;
using MySensors.ApplicationCore.Extensions;
using MySensors.ApplicationCore.Interfaces;
using MySensors.ApplicationCore.Specifications;

namespace MySensors.ApplicationCore.Services
{
    public class SensorsService : ISensorsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAsyncRepository<int, Sensor> _sensorRepository;
        private readonly IAsyncRepository<int, SensorParameterValue> _sensorParameterValuesRepository;
        private readonly IMapper<Sensor, SensorDTO> _sensorMapper;
        
        public SensorsService(IUnitOfWork uow, IMapper<Sensor, SensorDTO> sensorMapper)
        {
            _uow = uow;
            _sensorRepository = _uow.GetRepository<IAsyncRepository<int, Sensor>>();
            _sensorParameterValuesRepository = _uow.GetRepository<IAsyncRepository<int, SensorParameterValue>>();
            _sensorMapper = sensorMapper;
        }

        public async Task<IEnumerable<SensorOverviewDTO>> GetSensorsOverview(string userId)
        {
            var spec = new SensorOverviewSpecification();
            var sensors = await _sensorRepository.ListAsync(spec);

            var dtos = new List<SensorOverviewDTO>();
            
            foreach (var sensor in sensors)
            {
                SensorOverviewDTO sensorOverviewDTO = new()
                {
                    Id = sensor.Id,
                    SensorName = sensor.SensorName,
                    LastUpdate = DateTime.Now.ToString("HH:mm MM/dd/yyyy")
                };
                
                var sensorOverviewParamsDTO = new List<SensorOverviewParameterDTO>();

                foreach (var param in sensor.SensorParameters)
                {
                    var paramValueSpec = new SensorParamLastValueSpecification(param.Id);
                    SensorParameterValue paramValue = await _sensorParameterValuesRepository.FirstOrDefaultAsync(paramValueSpec);

                    var asdsa = new SensorOverviewParameterDTO()
                    {
                        HumanReadableName = param.HumanReadableName,
                        Value = paramValue?.Value
                    };
                    sensorOverviewParamsDTO.Add(asdsa);
                }

                sensorOverviewDTO.SensorParameters = sensorOverviewParamsDTO;
                dtos.Add(sensorOverviewDTO);
            }
            return dtos;
        }
        
        public async Task AddSensor(SensorDTO sensor)
        {
            Sensor sensorEntity = _sensorMapper.Map(sensor);
            var token = SensorTokenGenerator.GenerateRandomUniqueToken();
            sensorEntity.SetNewToken(token);
            await _sensorRepository.AddAsync(sensorEntity);
            await _uow.SaveChanges();
        }

        public async Task ChangeName(int sensorId, string name)
        {
            Sensor sensorEntity = await _sensorRepository.GetByIdAsync(sensorId);
            if(sensorEntity == null)
                throw new EntityNotFoundException();
            sensorEntity.UpdateSensorName(name);
            await _sensorRepository.UpdateAsync(sensorEntity);
            await _uow.SaveChanges();
        }
        
        public async Task ChangeToken(int id)
        {
            Sensor sensorEntity = await _sensorRepository.GetByIdAsync(id);
            if(sensorEntity == null)
                throw new EntityNotFoundException();
            var token = SensorTokenGenerator.GenerateRandomUniqueToken();
            sensorEntity.SetNewToken(token);
            await _sensorRepository.UpdateAsync(sensorEntity);
            await _uow.SaveChanges();
        }
        
        public async Task RemoveSensor(int id)
        {
            Sensor sensorEntity = await _sensorRepository.GetByIdAsync(id);
            if(sensorEntity  == null)
                throw new EntityNotFoundException();
            _sensorRepository.Delete(sensorEntity);
            await _uow.SaveChanges();
        }
        
        public async Task AddNewData(int id)
        {
            Sensor sensorEntity = await _sensorRepository.GetByIdAsync(id);
            if(sensorEntity  == null)
                throw new EntityNotFoundException();
            _sensorRepository.Delete(sensorEntity);
            await _uow.SaveChanges();
        }

        public async Task<string> GetOwnerUserId(int sensorId)
        {
            var spec = new SensorOnlyUserIdSpecification(sensorId);
            var sensor = await _sensorRepository.FirstAsync(spec);
            if(sensor == null)
                throw new EntityNotFoundException();

            return sensor.UserId;
        }
    }
}