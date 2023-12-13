using Instrument.API.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Instrument.API.Domain.Entities;
using Instrument.API.Models;
using AutoMapper;

namespace Instrument.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeInstrumentController : ControllerBase
    {
        private readonly ITypeInstrumentService _typeInstrumentService;
        private readonly IMapper _mapper;

        public TypeInstrumentController(IMapper mapper, ITypeInstrumentService typeInstrumentService)
        {
            _mapper = mapper;
            _typeInstrumentService = typeInstrumentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typeInstrumentService.GetAllTypes());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TypeInstrumentModel typeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _typeInstrumentService.Add(_mapper.Map<TypeInstrument>(typeModel));
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, typeModel);
        }
    }
}
