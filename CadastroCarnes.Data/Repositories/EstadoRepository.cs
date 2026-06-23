using CadastroCarnes.Data.Context;
using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace CadastroCarnes.Data.Repositories;


public class EstadoRepository : IEstadoRepository
{

    private readonly AppDbContext _context;


    public EstadoRepository(AppDbContext context)
    {
        _context = context;
    }



 public async Task<List<Estado>> GetAllAsync()
{
    return await _context.Estados
        .Include(x => x.Cidades)
        .AsNoTracking()
        .OrderBy(x => x.Nome)
        .ToListAsync();
}





public async Task<Estado?> GetByIdAsync(int id)
{
    return await _context.Estados
        .Include(x => x.Cidades)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);
}






    public async Task AddAsync(Estado estado)
    {
        await _context.Estados.AddAsync(estado);

        await _context.SaveChangesAsync();
    }







    public async Task UpdateAsync(Estado estado)
    {
        _context.Estados.Update(estado);

        await _context.SaveChangesAsync();
    }








    public async Task DeleteAsync(Estado estado)
    {
        _context.Estados.Remove(estado);

        await _context.SaveChangesAsync();
    }


}