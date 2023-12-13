using Instrument.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instrument.API.Infra.Data.EntityConfiguration
{

    public class TypeInstrumentConfigurationMap : IEntityTypeConfiguration<TypeInstrument>
    {
        public void Configure(EntityTypeBuilder<TypeInstrument> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(250);
        }
    }

}
