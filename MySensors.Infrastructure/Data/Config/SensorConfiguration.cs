using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySensors.ApplicationCore.Entities;

namespace MySensors.Infrastructure.Data.Config
{
    public class SensorConfiguration: IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(s => s.SensorParameters)
                .WithOne()
                .HasForeignKey(p => p.SensorId);
        }
    }
}