using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Infra.Data.Context;

namespace Instrument.API.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InstrumentContext context) : base(context)
        {

        }
    }
}
