using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Infra.Data.Context;

namespace Instrument.API.Infra.Data.Repository
{
    public class TypeInstrumentRepository : BaseRepository<TypeInstrument>, ITypeInstrumentRepository
    {
        public TypeInstrumentRepository(InstrumentContext context) : base(context)
        {

        }
    }
}
