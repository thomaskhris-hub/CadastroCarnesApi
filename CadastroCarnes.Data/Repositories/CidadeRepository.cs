using CadastroCarnes.Data.Context;
using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace CadastroCarnes.Data.Repositories;


public class CidadeRepository : ICidadeRepository
{


    private readonly AppDbContext _context;



    public CidadeRepository(AppDbContext context)
    {
        _context = context;
    }







    public async Task<List<Cidade>> GetAllAsync()
    {

        return await _context.Cidades

            .Include(x=>x.Estado)

            .AsNoTracking()

            .ToListAsync();

    }







    public async Task<Cidade?> GetByIdAsync(int id)
    {

        return await _context.Cidades

            .Include(x=>x.Estado)

            .FirstOrDefaultAsync(
                x=>x.Id == id
            );

    }








    public async Task AddAsync(Cidade cidade)
    {

        await _context.Cidades.AddAsync(cidade);


        await _context.SaveChangesAsync();

    }








    public async Task UpdateAsync(Cidade cidade)
    {

        _context.Cidades.Update(cidade);


        await _context.SaveChangesAsync();

    }








    public async Task DeleteAsync(Cidade cidade)
    {

        _context.Cidades.Remove(cidade);


        await _context.SaveChangesAsync();

    }


}