using CadastroCarnes.Model.DTOs;

namespace CadastroCarnes.Service.Interfaces;

public interface IPedidoService
{
    Task<int> CriarPedido(PedidoDto dto);

    Task<IEnumerable<PedidoDto>> ListarPedidos();

    Task<PedidoDto?> ObterPorId(int id);

    Task<bool> AtualizarPedido(int id, PedidoDto dto);

    Task<bool> ExcluirPedido(int id);
}