using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySensorsAppContext _context;
        private readonly Dictionary<Type, IRepository> _repositories = new Dictionary<Type, IRepository>();

        public UnitOfWork(MySensorsAppContext context, IAsyncRepository<int, Sensor> sensorRepository,
            IAsyncRepository<int, SensorParameter> sensorParametersRepository, 
            IAsyncRepository<int, SensorParameterValue> sensorParametersValueRepository,
            IAsyncRepository<int, SensorUpdateTime> sensorUpdateTimeRepository)
        {
            _context = context;
            _repositories.Add(typeof(IAsyncRepository<int, Sensor>), sensorRepository);
            _repositories.Add(typeof(IAsyncRepository<int, SensorParameter>), sensorParametersRepository);
            _repositories.Add(typeof(IAsyncRepository<int, SensorParameterValue>), sensorParametersValueRepository);
            _repositories.Add(typeof(IAsyncRepository<int, SensorUpdateTime>), sensorUpdateTimeRepository);
        }
        
        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            if (!_repositories.ContainsKey(typeof(TRepository)))
                throw new ArgumentException("Repository does not exist!");
                
            return (TRepository)_repositories[typeof(TRepository)];
        }

        public async Task<bool> SaveChanges()
        {
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}