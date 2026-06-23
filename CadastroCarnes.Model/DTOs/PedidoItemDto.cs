using CadastroCarnes.Model.Enums;

namespace CadastroCarnes.Model.DTOs;

public class PedidoItemDto
{
    public int CarneId { get; set; }

    public decimal Preco { get; set; }

    public TipoMoeda Moeda { get; set; }
}