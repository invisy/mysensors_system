using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySensors.ApplicationCore.Entities;

namespace MySensors.Infrastructure.Data.Config
{
    public class SensorParametersConfiguration: IEntityTypeConfiguration<SensorParameter>
    {
        public void Configure(EntityTypeBuilder<SensorParameter> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(s => s.SensorParameterValues)
                .WithOne(p => p.SensorParameter)
                .HasForeignKey(p => p.SensorParameterId);
        }
    }
}