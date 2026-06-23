using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.DTOs;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;

namespace CadastroCarnes.Service.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;

    public PedidoService(IPedidoRepository repository)
    {
        _repository = repository;
    }


    public async Task<int> CriarPedido(PedidoDto dto)
    {
        var pedido = new Pedido
        {
            CompradorId = dto.CompradorId,
            DataPedido = DateTime.Now,

            Itens = dto.Itens.Select(x => new PedidoItem
            {
                CarneId = x.CarneId,
                Preco = x.Preco,
                Moeda = x.Moeda

            }).ToList()
        };


        await _repository.Adicionar(pedido);

        return pedido.Id;
    }



    public async Task<PedidoDto?> ObterPorId(int id)
    {
        var pedido = await _repository.ObterPorId(id);


        if (pedido == null)
            return null;


        return new PedidoDto
        {
            Id = pedido.Id,

            CompradorId = pedido.CompradorId,

            Itens = pedido.Itens.Select(i => new PedidoItemDto
            {
                CarneId = i.CarneId,
                Preco = i.Preco,
                Moeda = i.Moeda

            }).ToList()
        };
    }



    public async Task<IEnumerable<PedidoDto>> ListarPedidos()
    {
        var pedidos = await _repository.ListarPedidos();

        return pedidos.Select(x => new PedidoDto
        {
            Id = x.Id,

            CompradorId = x.CompradorId,

            Itens = x.Itens.Select(i => new PedidoItemDto
            {
                CarneId = i.CarneId,
                Preco = i.Preco,
                Moeda = i.Moeda

            }).ToList()

        });
    }



    public async Task<bool> AtualizarPedido(int id, PedidoDto dto)
    {
        var pedido = await _repository.ObterPorId(id);


        if (pedido == null)
            return false;


        pedido.CompradorId = dto.CompradorId;


        pedido.Itens.Clear();


        foreach (var item in dto.Itens)
        {
            pedido.Itens.Add(new PedidoItem
            {
                CarneId = item.CarneId,
                Preco = item.Preco,
                Moeda = item.Moeda
            });
        }


        await _repository.Atualizar(pedido);

        return true;
    }



    public async Task<bool> ExcluirPedido(int id)
    {
        var pedido = await _repository.ObterPorId(id);


        if (pedido == null)
            return false;


        await _repository.Remover(pedido);

        return true;
    }
}