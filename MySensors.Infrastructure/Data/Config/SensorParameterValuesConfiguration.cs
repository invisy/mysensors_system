using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySensors.ApplicationCore.Entities;

namespace MySensors.Infrastructure.Data.Config
{
    public class SensorParameterValuesConfiguration: IEntityTypeConfiguration<SensorParameterValue>
    {
        public void Configure(EntityTypeBuilder<SensorParameterValue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(s => s.SensorUpdateTime)
                .WithMany()
                .HasForeignKey(v => v.SensorUpdateTimeId);
        }
    }
}