using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace MySensors.Infrastructure.Data
{
    public class MySensorsAppContext : DbContext
    { 
        public MySensorsAppContext(DbContextOptions<MySensorsAppContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}