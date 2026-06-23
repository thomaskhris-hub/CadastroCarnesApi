namespace CadastroCarnes.Model.DTOs;

public class PedidoDto
{
    public int Id { get; set; }

    public int CompradorId { get; set; }

    public List<PedidoItemDto> Itens { get; set; } = new();
}