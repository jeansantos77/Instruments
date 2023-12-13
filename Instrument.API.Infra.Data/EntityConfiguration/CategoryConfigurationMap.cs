using Instrument.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instrument.API.Infra.Data.EntityConfiguration
{
    public class CategoryConfigurationMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(c => c.Operator)
            .HasConversion<int>()
            .IsRequired();

            builder.Property(c => c.StartValue)
            .IsRequired();

        }
    }
}
