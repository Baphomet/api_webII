namespace webII_API.Models
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public double Preco { get; set; }

    }
}
