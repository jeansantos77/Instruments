using AutoMapper;
using Instrument.API.Domain.Entities;
using Instrument.API.Models;

namespace Instrument.API.AutoMapper
{
    public class AutoMappings : Profile
    {
        public AutoMappings() {
            CreateMap<Category, CategoryModel>()
                .ReverseMap();
            CreateMap<TypeInstrument, TypeInstrumentModel>()
                .ReverseMap();
        }
    }
}
