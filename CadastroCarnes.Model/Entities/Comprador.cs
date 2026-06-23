namespace CadastroCarnes.Model.Entities;

public class Comprador
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Documento { get; set; } = string.Empty;

    public int CidadeId { get; set; }

    public Cidade? Cidade { get; set; }

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}