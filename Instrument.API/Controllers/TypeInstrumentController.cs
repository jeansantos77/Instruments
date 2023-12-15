using Instrument.API.Application.Interfaces;
using Instrument.API.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Instrument.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeInstrumentController : ControllerBase
    {
        private readonly ITypeInstrumentService _typeInstrumentService;

        public TypeInstrumentController(ITypeInstrumentService typeInstrumentService)
        {
            _typeInstrumentService = typeInstrumentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typeInstrumentService.GetAllTypes());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _typeInstrumentService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TypeInstrumentAddModel typeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _typeInstrumentService.Add(typeModel);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, typeModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TypeInstrumentModel typeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _typeInstrumentService.Update(typeModel);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok(typeModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _typeInstrumentService.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

            return Ok();
        }


    }
}
