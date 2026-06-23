using CadastroCarnes.Data.Context;
using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroCarnes.Data.Repositories;

public class CompradorRepository : ICompradorRepository
{
    private readonly AppDbContext _context;


    public CompradorRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Comprador>> GetAllAsync()
    {
        return await _context.Compradores
            .Include(x => x.Cidade)
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<Comprador?> GetByIdAsync(int id)
    {
        return await _context.Compradores
            .Include(x => x.Cidade)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task AddAsync(Comprador comprador)
    {
        await _context.Compradores.AddAsync(comprador);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(Comprador comprador)
    {
        _context.Compradores.Update(comprador);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Comprador comprador)
    {
        _context.Compradores.Remove(comprador);
        await _context.SaveChangesAsync();
    }


    public async Task<bool> HasPedidosAsync(int compradorId)
    {
        return await _context.Pedidos
            .AnyAsync(x => x.CompradorId == compradorId);
    }
}