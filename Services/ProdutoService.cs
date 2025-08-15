using Microsoft.EntityFrameworkCore;
using webII_API.Context;
using webII_API.DTOs;
using webII_API.Models;

namespace webII_API.Services
{
    public class ProdutoService
    {
        public readonly Db _context;
        public ProdutoService (Db context)
        {
            _context = context;
        }
        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _context.Produtos
                .ToListAsync();
        }
        public async Task<string> AddProduto(ProdutoDTO dto)
        {
            Produto produto = new Produto();
            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return "Produto adicionado com sucesso!";
        }
        public async Task<string> UpdateProduto(Guid id, ProdutoDTO dto)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (produto == null) return "Produto não encontrado!";

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return "Produto atualizado com sucesso!";
        }
        public async Task<string> DeleteProduto(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return "Produto não encontrado";

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return "Produto removido com sucesso!";

        }
    }
}
