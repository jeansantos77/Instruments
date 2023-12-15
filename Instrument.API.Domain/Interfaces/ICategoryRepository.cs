using Instrument.API.Domain.Entities;
using System.Threading.Tasks;

namespace Instrument.API.Domain.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<string> CalculateCategory(double value);
    }
}
