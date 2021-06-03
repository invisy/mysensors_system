using Microsoft.Extensions.DependencyInjection;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;
using MySensors.ApplicationCore.Mappers;
using MySensors.ApplicationCore.Services;

namespace MySensors.ApplicationCore
{
    public static class CoreServicesBinder
    {
        public static IServiceCollection BindCoreLayer(this IServiceCollection services)
        {
            services.AddSingleton<IMapper<SensorParameter, SensorParameterDTO>, SensorParameterMapper>();
            services.AddSingleton<IMapper<Sensor, SensorDTO>, SensorMapper>();
            
            services.AddScoped<ISensorsService, SensorsService>();

            return services;
        }
    }
}