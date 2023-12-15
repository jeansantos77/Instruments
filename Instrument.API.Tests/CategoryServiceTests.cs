using AutoMapper;
using Instrument.API.Application.Implementations;
using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Enumerators;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Domain.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Instrument.API.Tests
{
    public class CategoryServiceTests
    {
        CategoryService _categoryService;

        public CategoryServiceTests()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<CategoryModel, Category>(It.IsAny<CategoryModel>())).Returns(GetCategory());

            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(s => s.GetById(It.IsAny<int>())).Returns(Task.FromResult(GetCategory()));

            _categoryService = new CategoryService(mockMapper.Object, mockCategory.Object);

        }

        [Fact]
        public async Task CategoryService_Should_Return_Exception_If_Name_is_Null()
        {
            //Arrange
            CategoryAddModel category = new();

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _categoryService.Add(category));
            Assert.Equal("Name must be informed!", exception.Message);
        }

        [Fact]
        public async Task CategoryService_Should_Return_Exception_If_EndValue_is_Wrong()
        {
            //Arrange
            CategoryAddModel category = new()
            {
                Name = "Medium Value",
                Operator = Operator.LessThen,
                StartValue = 10000,
                EndValue = 20000
            };

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _categoryService.Add(category));
            Assert.Equal("Only Between operator must be EndValue informed!", exception.Message);
        }

        [Fact]
        public async Task CategoryService_Should_Return_Exception_If_Try_Delete_Category_Not_Found()
        {
            //Arrange
            CategoryModel category = new()
            {
                Id = 1, 
                Name = "Medium Value",
                Operator = Operator.LessThen,
                StartValue = 10000,
                EndValue = 20000
            };

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _categoryService.Delete(category.Id));
            Assert.Equal($"Category with [ Id = {category.Id}] not found.", exception.Message);
        }

        [Fact]
        public void CategoryService_Should_Not_Return_Exception_If_Try_Update_Category()
        {
            //Arrange
            CategoryModel category = new CategoryModel
            {
                Id = 1,
                Name = "High Value",
                Operator = Operator.GreaterThan,
                StartValue = 5000000
            };

            //Assert
            var exception = Record.ExceptionAsync(() => _categoryService.Update(category));
            Assert.Null(exception.Result);
        }


        private Category GetCategory()
        {
            Category category = new()
            {
                Id = 1,
                Name = "Medium Value",
                Operator = Operator.LessThen,
                StartValue = 10000,
                EndValue = 20000
            };

            return category;

        }
    }
}
