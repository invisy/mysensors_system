using System.Collections.Generic;
using System.Threading.Tasks;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;
using MySensors.ApplicationCore.Specifications;

namespace MySensors.ApplicationCore.Services
{
    public class SensorParametersService: ISensorParametersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAsyncRepository<int, SensorParameter> _sensorParameterRepository;
        private readonly IMapper<SensorParameter, SensorParameterDTO> _sensorParametersMapper;

        public SensorParametersService(IUnitOfWork uow, IMapper<SensorParameter, SensorParameterDTO> sensorParametersMapper)
        {
            _uow = uow;
            _sensorParametersMapper = sensorParametersMapper;
            _sensorParameterRepository = _uow.GetRepository<IAsyncRepository<int, SensorParameter>>();
        }

        public async Task<IEnumerable<SensorParameterDTO>> GetBySensorId(int id)
        {
            var spec = new SensorParametersSpecification(id);
            var sensorParams = await _sensorParameterRepository.ListAsync(spec);

            return _sensorParametersMapper.Map(sensorParams);
        }
    }
}