using Instrument.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instrument.API.Application.Interfaces
{
    public interface ITypeInstrumentService
    {
        Task Add(TypeInstrumentAddModel entity);
        Task Update(TypeInstrumentModel entity);
        Task Delete(int id);
        Task<TypeInstrumentModel> GetById(int id);
        Task<List<TypeInstrumentModel>> GetAllTypes();
    }
}
