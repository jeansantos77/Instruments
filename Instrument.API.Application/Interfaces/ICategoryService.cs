using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instrument.API.Application.Interfaces
{
    public interface ICategoryService 
    {
        Task Add(CategoryAddModel entity);
        Task Update(CategoryModel entity);
        Task Delete(int id);
        Task<CategoryModel> GetById(int id);
        Task<List<CategoryModel>> GetAllCategories();
    }
}
