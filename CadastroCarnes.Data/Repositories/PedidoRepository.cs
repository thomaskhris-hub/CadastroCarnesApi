using CadastroCarnes.Data.Context;
using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroCarnes.Data.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task Adicionar(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);

        await _context.SaveChangesAsync();
    }


    public async Task<Pedido?> ObterPorId(int id)
    {
        return await _context.Pedidos
            .Include(x => x.Itens)
            .ThenInclude(x => x.Carne)
            .Include(x => x.Comprador)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<List<Pedido>> Listar()
    {
        return await _context.Pedidos
            .Include(x => x.Itens)
            .ToListAsync();
    }


    public async Task<List<Pedido>> ListarPedidos()
    {
        return await _context.Pedidos
            .Include(x => x.Itens)
            .ThenInclude(x => x.Carne)
            .Include(x => x.Comprador)
            .ToListAsync();
    }


    public async Task Atualizar(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);

        await _context.SaveChangesAsync();
    }


    public async Task Remover(Pedido pedido)
    {
        _context.Pedidos.Remove(pedido);

        await _context.SaveChangesAsync();
    }
}