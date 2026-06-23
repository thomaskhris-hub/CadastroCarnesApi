using CadastroCarnes.Data.Context;
using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroCarnes.Data.Repositories;

public class CarneRepository : ICarneRepository
{
    private readonly AppDbContext _context;


    public CarneRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Carne>> GetAllAsync()
    {
        return await _context.Carnes
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<Carne?> GetByIdAsync(int id)
    {
        return await _context.Carnes
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task AddAsync(Carne carne)
    {
        await _context.Carnes.AddAsync(carne);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(Carne carne)
    {
        _context.Carnes.Update(carne);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Carne carne)
    {
        _context.Carnes.Remove(carne);
        await _context.SaveChangesAsync();
    }


    public async Task<bool> HasPedidosAsync(int carneId)
    {
        return await _context.PedidoItens
            .AnyAsync(x => x.CarneId == carneId);
    }
}