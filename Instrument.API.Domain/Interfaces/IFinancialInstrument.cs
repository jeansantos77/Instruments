namespace Instrument.API.Domain.Interfaces
{
    public interface IFinancialInstrument
    {
        double MarketValue { get; }
        string Type { get; }
    }
}
