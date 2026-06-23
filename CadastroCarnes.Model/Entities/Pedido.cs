namespace CadastroCarnes.Model.Entities;

public class Pedido
{
    public int Id { get; set; }

    public DateTime DataPedido { get; set; }

    public int CompradorId { get; set; }

   public Comprador Comprador { get; set; } = null!;

    public ICollection<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
}