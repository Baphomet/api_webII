using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webII_API.DTOs;
using webII_API.Services;

namespace webII_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        public readonly ComandaService _services;

        public ComandaController(ComandaService Comandaservice)
        {
            _services = Comandaservice;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllComandas());
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ComandaDTO dto)
        {
            string resultado = await _services.AddComanda(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(resultado);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>Updadte(Guid id, [FromBody] ComandaDTO dto)
        {
            string resultado = await _services.UpdateComanda(id, dto);
            if (resultado.Contains("não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteComanda(id);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
    }
}
