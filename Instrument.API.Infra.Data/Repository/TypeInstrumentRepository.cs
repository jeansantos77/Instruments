using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Instrument.API.Infra.Data.Repository
{
    public class TypeInstrumentRepository : BaseRepository<TypeInstrument>, ITypeInstrumentRepository
    {
        public TypeInstrumentRepository(InstrumentContext context) : base(context)
        {

        }

        public override async Task<TypeInstrument> GetById(int id)
        {
            return await _dbContext.Set<TypeInstrument>().Where(t => t.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TypeInstrument> GetByName(string name)
        {
            return await _dbContext.Set<TypeInstrument>().Where(t => t.Name == name).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
