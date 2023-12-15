using AutoMapper;
using Instrument.API.Application.Interfaces;
using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Enumerators;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instrument.API.Application.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task Add(CategoryAddModel entity)
        {
            if (entity.Name == null)
            {
                throw new Exception("Name must be informed!");
            }

            if (entity.Operator != Operator.Between && entity.EndValue > 0)
            {
                throw new Exception("Only Between operator must be EndValue informed!");
            }

            Category category = _mapper.Map<Category>(entity);
            await _categoryRepository.Add(category);
        }

        public async Task Delete(int id)
        {
            CategoryModel category = await GetById(id);

            if (category == null)
            {
                throw new Exception($"Category with [ Id = {id}] not found.");
            }

            Category entity = _mapper.Map<Category>(category);

            await _categoryRepository.Delete(entity);
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var entities = await _categoryRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<CategoryModel>>(entities);
        }

        public async Task<CategoryModel> GetById(int id)
        {
            Category entity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryModel>(entity);
        }

        public async Task Update(CategoryModel entity)
        {
            Category category = _mapper.Map<Category>(entity);
            await _categoryRepository.Update(category);
        }
    }
}
