using CadastroCarnes.Model.Entities;


namespace CadastroCarnes.Data.Repositories.Interfaces;


public interface ICidadeRepository
{

    Task<List<Cidade>> GetAllAsync();


    Task<Cidade?> GetByIdAsync(int id);


    Task AddAsync(Cidade cidade);


    Task UpdateAsync(Cidade cidade);


    Task DeleteAsync(Cidade cidade);

}