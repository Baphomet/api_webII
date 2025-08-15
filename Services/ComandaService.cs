using Microsoft.EntityFrameworkCore;
using webII_API.Context;
using webII_API.DTOs;
using webII_API.Models;

namespace webII_API.Services
{
    public class ComandaService
    {
        public readonly Db _context;
        public ComandaService(Db context)
        {
            _context = context;
        }
        public async Task<List<Comanda>> GetAllComandas()
        {
            return await _context.Comandas
                .Include(c => c.Usuario)
                .ToListAsync();
        }
        public async Task<string> AddComanda(ComandaDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null) return "Usuário não encontrado";

            Comanda comanda = new Comanda();
            comanda.NomeUsuario = dto.NomeUsuario;
            comanda.TelefoneUsuario = dto.NomeUsuario;
            comanda.Usuario = usuario;

            await _context.Comandas.AddAsync(comanda);
            await _context.SaveChangesAsync();
            return "Comanda adicionada com sucesso!";
        }
        public async Task<string> UpdateComanda(Guid id, ComandaDTO dto)
        {
            var comanda = await _context.Comandas.Include(c => c.Usuario).FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (comanda == null) return "Comanda não encontrada!";

            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null) return "Usuário não encontrado";

            comanda.NomeUsuario = dto.NomeUsuario;
            comanda.TelefoneUsuario = dto.TelefoneUsuario;
            comanda.Usuario = usuario;

            _context.Comandas.Update(comanda);
            await _context.SaveChangesAsync();
            return "Comanda atualizada com sucesso!";
        }
        public async Task<string> DeleteComanda(Guid id)
        {
            var comanda = await _context.Comandas.Include(c => c.Usuario).FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (comanda == null) return "Comanda não encontrada!";

            _context.Comandas.Remove(comanda);
            await _context.SaveChangesAsync();
            return "Comanda removida com sucesso!";
        }
    }
}
