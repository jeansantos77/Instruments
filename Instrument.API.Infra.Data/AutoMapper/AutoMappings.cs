using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Models;
using AutoMapper;

namespace Instrument.API.Infra.Data.AutoMapper
{
    public class AutoMappings : Profile
    {
        public AutoMappings() 
        {
            CreateMap<CategoryAddModel, Category>()
                .ReverseMap();
            CreateMap<CategoryModel, Category>()
                .ReverseMap();
            CreateMap<TypeInstrumentAddModel, TypeInstrument>()
                .ReverseMap();
            CreateMap<TypeInstrumentModel, TypeInstrument>()
                .ReverseMap();

        }
    }
}
