using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webII_API.DTOs;
using webII_API.Services;

namespace webII_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public readonly ProdutoService _services;

        public ProdutoController(ProdutoService Produtoservice)
        {
            _services = Produtoservice;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _services.GetAllProdutos());
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ProdutoDTO dto)
        {
            string resultado = await _services.AddProduto(dto);
            if (resultado.Contains("Não")) return BadRequest(resultado);
            return Ok(resultado);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] ProdutoDTO dto)
        {
            string resultado = await _services.UpdateProduto(id, dto);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            string resultado = await _services.DeleteProduto(id);
            if (resultado.Contains("Não encontrado")) return NotFound(resultado);
            return Ok(resultado);
        }

    }
}
