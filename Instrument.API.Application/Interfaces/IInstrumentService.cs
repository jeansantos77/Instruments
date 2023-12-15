using Instrument.API.Domain.Interfaces;
using Instrument.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instrument.API.Application.Interfaces
{
    public interface IInstrumentService
    {
        Task<List<string>> ReturnCategories(List<FinancialInstrumentModel> financialInstruments);
    }
}
