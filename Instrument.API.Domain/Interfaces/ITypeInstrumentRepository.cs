using Instrument.API.Domain.Entities;
using System.Threading.Tasks;

namespace Instrument.API.Domain.Interfaces
{
    public interface ITypeInstrumentRepository : IBaseRepository<TypeInstrument>
    {
        Task<TypeInstrument> GetByName(string name);
    }
}
