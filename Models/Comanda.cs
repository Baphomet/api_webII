namespace webII_API.Models
{
    public class Comanda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int TelefoneUsuario { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public Usuario Usuario { get; set; }

    }
}
