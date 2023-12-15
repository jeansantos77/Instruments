using Instrument.API.Application.Implementations;
using Instrument.API.Domain.Entities;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Domain.Models;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Instrument.API.Tests
{
    public class InstrumentServiceTests
    {
        InstrumentService _instrumentService;

        public InstrumentServiceTests()
        {
            var mockCategory = new Mock<ICategoryRepository>();
            mockCategory.Setup(s => s.CalculateCategory(It.IsAny<double>())).Returns(Task.FromResult("Low Value"));

            var mockTypeInstrument = new Mock<ITypeInstrumentRepository>();
            mockTypeInstrument.Setup(s => s.GetByName(It.IsAny<string>())).Returns(Task.FromResult(new TypeInstrument { Id = 1, Name = "Stocks"}));

            _instrumentService = new InstrumentService(mockCategory.Object, mockTypeInstrument.Object);
        }

        [Fact]
        public void InstrumentService_Should_Return_Categories()
        {
            //Act
            List<FinancialInstrumentModel> financialInstruments = new List<FinancialInstrumentModel>
            {
                new() { MarketValue = 800000 , Type = "Stock" }
            };

            //Assert
            var exception = Record.ExceptionAsync(() => _instrumentService.ReturnCategories(financialInstruments));
            Assert.Null(exception.Result);
        }
    }
}
