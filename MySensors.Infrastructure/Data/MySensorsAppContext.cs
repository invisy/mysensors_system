using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using MySensors.ApplicationCore.Entities;

namespace MySensors.Infrastructure.Data
{
    public class MySensorsAppContext : DbContext
    {
        protected DbSet<Sensor> Sensors { get; set; }
        protected DbSet<SensorParameter> SensorsParameters { get; set; }
        protected DbSet<SensorParameterValue> SensorParameterValues { get; set; }
        
        public MySensorsAppContext(DbContextOptions<MySensorsAppContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}