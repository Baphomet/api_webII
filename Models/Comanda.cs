namespace webII_API.Models
{
    public class Comanda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    }
}
