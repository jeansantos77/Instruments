using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Instrument.API.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InstrumentContext context) : base(context)
        {

        }

        public async Task<string> CalculateCategory(double value)
        {
            Category category = (await GetAll(c => c.StartValue <= value && c.EndValue >= value)).FirstOrDefault();

            if (category == null)
            {
                category = (await GetAll(c => c.StartValue > value && c.EndValue == 0)).FirstOrDefault();
            }

            if (category == null)
            {
                category = (await GetAll(c => c.StartValue < value && c.EndValue == 0)).OrderByDescending(c => c.StartValue).FirstOrDefault();
            }

            return category.Name;
        }

        public override async Task<Category> GetById(int id)
        {
            return await _dbContext.Set<Category>().Where(t => t.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
