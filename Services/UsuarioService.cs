using Microsoft.EntityFrameworkCore;
using webII_API.Context;
using webII_API.DTOs;
using webII_API.Models;

namespace webII_API.Services
{
    public class UsuarioService
    {
        public readonly Db _context;

        public UsuarioService(Db context)
        {
            _context = context;
        }
        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios
                .ToListAsync();
        }
        public async Task<string> AddUsuario(UsuarioDTO dto)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = dto.Nome;
            usuario.Numero = dto.Numero;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return "Usuario adicionado com sucesso!";

        }
        public async Task<string> UpdateUsuario (Guid id, UsuarioDTO dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(id));
            if (usuario == null) return "Usuario não encontrado!";

            usuario.Nome = dto.Nome;
            usuario.Nome = dto.Numero;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return "Usuario atualizado com sucesso!";
        }
        public async Task<string> DeleteUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return "Usuario não encontrado";

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return "Usuario removido com sucesso!";
        }
    }
}
