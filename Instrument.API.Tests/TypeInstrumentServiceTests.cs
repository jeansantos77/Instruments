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
    public class TypeInstrumentServiceTests
    {
        TypeInstrumentService _typeInstrumentService;

        public TypeInstrumentServiceTests()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<TypeInstrumentModel, TypeInstrument>(It.IsAny<TypeInstrumentModel>())).Returns(GetTypeInstrument());

            var mockTypeInstrument = new Mock<ITypeInstrumentRepository>();
            mockTypeInstrument.Setup(s => s.GetById(It.IsAny<int>())).Returns(Task.FromResult(GetTypeInstrument()));

            _typeInstrumentService = new TypeInstrumentService(mockMapper.Object, mockTypeInstrument.Object);

        }

        [Fact]
        public async Task TypeInstrumentService_Should_Return_Exception_If_Name_is_Null()
        {
            //Arrange
            TypeInstrumentAddModel typeInstrument = new();

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _typeInstrumentService.Add(typeInstrument));
            Assert.Equal("Name must be informed!", exception.Message);
        }

        [Fact]
        public async Task TypeInstrumentService_Should_Return_Exception_If_Try_Delete_Category_Not_Found()
        {
            //Arrange
            TypeInstrumentModel typeInstrument = new()
            {
                Id = 1, 
                Name = "Stock"
            };

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _typeInstrumentService.Delete(typeInstrument.Id));
            Assert.Equal($"Type Instrument with [ Id = {typeInstrument.Id}] not found.", exception.Message);
        }

        [Fact]
        public void TypeInstrumentService_Should_Not_Return_Exception_If_Try_Update_Category()
        {
            //Arrange
            TypeInstrumentModel typeInstrument = new TypeInstrumentModel
            {
                Id = 1,
                Name = "Stock - Update"
            };

            //Assert
            var exception = Record.ExceptionAsync(() => _typeInstrumentService.Update(typeInstrument));
            Assert.Null(exception.Result);
        }


        private TypeInstrument GetTypeInstrument()
        {
            TypeInstrument typeInstrument = new()
            {
                Id = 1,
                Name = "Stock"
            };

            return typeInstrument;

        }
    }
}
