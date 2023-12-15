using Instrument.API.Domain.Interfaces;

namespace Instrument.API.Domain.Models
{
    public class FinancialInstrumentModel : IFinancialInstrument
    {
        public double MarketValue { get; set; }
        public string Type { get; set; }
    }
}
