using Instrument.API.Domain.Enumerators;

namespace Instrument.API.Domain.Entities
{
    public class Category : Base
    {
        public string Name { get; set; }
        public Operator Operator { get; set; }
        public double StartValue { get; set; }
        public double EndValue { get; set; }
    }
}
