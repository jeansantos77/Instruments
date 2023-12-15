using Instrument.API.Application.Interfaces;
using Instrument.API.Domain.Interfaces;
using Instrument.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instrument.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrumentService _instrumentService;

        public InstrumentController(IInstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] List<FinancialInstrumentModel> model)
        {
            return Ok(await _instrumentService.ReturnCategories(model));
        }


    }
}
