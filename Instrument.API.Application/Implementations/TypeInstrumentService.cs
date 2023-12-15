using AutoMapper;
using Instrument.API.Application.Interfaces;
using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instrument.API.Application.Implementations
{
    public class TypeInstrumentService : ITypeInstrumentService
    {
        private readonly IMapper _mapper;
        private readonly ITypeInstrumentRepository _typeInstrumentRepository;

        public TypeInstrumentService(IMapper mapper, ITypeInstrumentRepository typeInstrumentRepository)
        {
            _mapper = mapper;
            _typeInstrumentRepository = typeInstrumentRepository;
        }

        public async Task Add(TypeInstrumentAddModel entity)
        {
            if (entity.Name == null)
            {
                throw new Exception("Name must be informed!");
            }

            TypeInstrument typeInstrument = _mapper.Map<TypeInstrument>(entity);
            await _typeInstrumentRepository.Add(typeInstrument);
        }

        public async Task Delete(int id)
        {
            TypeInstrumentModel typeInstrument = await GetById(id);

            if (typeInstrument == null)
            {
                throw new Exception($"Type Instrument with [ Id = {id}] not found.");
            }

            TypeInstrument entity = _mapper.Map<TypeInstrument>(typeInstrument);

            await _typeInstrumentRepository.Delete(entity);
        }

        public async Task<TypeInstrumentModel> GetById(int id)
        {
            TypeInstrument entity = await _typeInstrumentRepository.GetById(id);
            return _mapper.Map<TypeInstrumentModel>(entity);
        }

        public async Task Update(TypeInstrumentModel entity)
        {
            TypeInstrument typeInstrument = _mapper.Map<TypeInstrument>(entity);
            await _typeInstrumentRepository.Update(typeInstrument);
        }

        public async Task<List<TypeInstrumentModel>> GetAllTypes()
        {
            var entities = await _typeInstrumentRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<TypeInstrumentModel>>(entities);
        }
    }
}
