using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySensors.ApplicationCore.Entities;

namespace MySensors.Infrastructure.Data.Config
{
    public class SensorUpdateTimeConfiguration: IEntityTypeConfiguration<SensorUpdateTime>
    {
        public void Configure(EntityTypeBuilder<SensorUpdateTime> builder)
        {
            builder.HasKey(x => x.Id);
            
        }
    }
}