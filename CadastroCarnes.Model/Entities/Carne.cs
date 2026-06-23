using CadastroCarnes.Model.Enums;

namespace CadastroCarnes.Model.Entities;

public class Carne
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public OrigemCarne Origem { get; set; }

    public ICollection<PedidoItem> PedidoItens { get; set; } = new List<PedidoItem>();
}