using Instrument.API.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace Instrument.API.Application.Interfaces
{
    public interface ITypeInstrumentService : IBaseService<TypeInstrument>
    {
        Task<List<TypeInstrument>> GetAllTypes();
    }
}
