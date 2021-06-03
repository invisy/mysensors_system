using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace MySensors.Infrastructure.Data
{
    public class MySensorsAppContext : DbContext
    { 
        public MySensorsAppContext(DbContextOptions<MySensorsAppContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}