using Instrument.API.Domain.Enumerators;

namespace Instrument.API.Models
{
    public class CategoryModel 
    {
        public string Name { get; set; }
        public Operator Operator { get; set; }
        public double StartValue { get; set; }
        public double EndValue { get; set; }
    }
}
