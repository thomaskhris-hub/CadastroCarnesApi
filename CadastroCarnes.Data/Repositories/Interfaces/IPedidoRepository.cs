using CadastroCarnes.Model.Entities;

namespace CadastroCarnes.Data.Repositories.Interfaces;

public interface IPedidoRepository
{
    Task Adicionar(Pedido pedido);

    Task<Pedido?> ObterPorId(int id);

    Task<List<Pedido>> Listar();

    Task<List<Pedido>> ListarPedidos();

    Task Atualizar(Pedido pedido);

    Task Remover(Pedido pedido);
}