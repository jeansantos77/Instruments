using Instrument.API.Application.Interfaces;
using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Instrument.API.Application.Implementations
{
    public class TypeInstrumentService : ITypeInstrumentService
    {
        private ITypeInstrumentRepository _typeInstrumentRepository;
        public TypeInstrumentService(ITypeInstrumentRepository typeInstrumentRepository)
        {
            _typeInstrumentRepository = typeInstrumentRepository;
        }

        public async Task Add(TypeInstrument entity)
        {
            await _typeInstrumentRepository.Add(entity);
        }

        public async Task Delete(int id)
        {
            TypeInstrument entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception($"Type Instrument with [ Id = {id}] not found.");
            }

            await _typeInstrumentRepository.Delete(entity);
        }

        public async Task<List<TypeInstrument>> GetAll(Expression<Func<TypeInstrument, bool>> predicate)
        {
            return await _typeInstrumentRepository.GetAll(predicate);
        }

        public async Task<TypeInstrument> GetById(int id)
        {
            return await _typeInstrumentRepository.GetById(id);
        }

        public async Task Update(TypeInstrument entity)
        {
            await _typeInstrumentRepository.Update(entity);
        }

        public async Task<List<TypeInstrument>> GetAllTypes()
        {
            return await _typeInstrumentRepository.GetAll(t => t.Id > 0);
        }
    }
}
