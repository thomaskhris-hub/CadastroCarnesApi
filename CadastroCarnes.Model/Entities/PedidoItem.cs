using CadastroCarnes.Model.Enums;

namespace CadastroCarnes.Model.Entities;

public class PedidoItem
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public Pedido? Pedido { get; set; }

    public int CarneId { get; set; }

    public Carne? Carne { get; set; }

    public decimal Preco { get; set; }

    public TipoMoeda Moeda { get; set; }
}