using Instrument.API.Domain.Entities;
using Instrument.API.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;


namespace Instrument.API.Infra.Data.Context
{
    public class InstrumentContext : DbContext
    {
        public InstrumentContext(DbContextOptions<InstrumentContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TypeInstrument> TypeInstruments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigurationMap());
            modelBuilder.ApplyConfiguration(new TypeInstrumentConfigurationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
