using Instrument.API.Application.Interfaces;
using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Instrument.API.Application.Implementations
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Add(Category entity)
        {
            await _categoryRepository.Add(entity);
        }

        public async Task Delete(int id)
        {
            Category category = await GetById(id);

            if (category == null)
            {
                throw new Exception($"Category with [ Id = {id}] not found.");
            }

            await _categoryRepository.Delete(category);
        }

        public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> predicate)
        {
            return await _categoryRepository.GetAll(predicate);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAll(t => t.Id > 0);
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task Update(Category entity)
        {
            await _categoryRepository.Update(entity);
        }
    }
}
