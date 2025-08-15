using Microsoft.EntityFrameworkCore;
using webII_API.Models;

namespace webII_API.Context
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
    }
}
