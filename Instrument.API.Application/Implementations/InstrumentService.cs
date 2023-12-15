using Instrument.API.Application.Interfaces;
using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instrument.API.Application.Implementations
{
    public class InstrumentService : IInstrumentService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITypeInstrumentRepository _typeInstrumentRepository;
        public InstrumentService(ICategoryRepository categoryRepository, ITypeInstrumentRepository typeInstrumentRepository)
        {
            _categoryRepository = categoryRepository;
            _typeInstrumentRepository = typeInstrumentRepository;
        }

        public async Task<List<string>> ReturnCategories(List<FinancialInstrumentModel> financialInstruments)
        {
            List<string> returnCategories = new();

            foreach (var financialInstrument in financialInstruments)
            {
                TypeInstrument typeInstrument = await _typeInstrumentRepository.GetByName(financialInstrument.Type);

                string nameCategory;

                if (typeInstrument == null)
                {
                    nameCategory = $"{financialInstrument.Type} not found!";
                }
                else
                {
                    nameCategory = await _categoryRepository.CalculateCategory(financialInstrument.MarketValue);
                }

                returnCategories.Add(nameCategory);
            }

            return returnCategories;
        }
    }
}
