using CadastroCarnes.Model.Entities;

namespace CadastroCarnes.Service.Interfaces;

public interface ICidadeService
{

    Task<List<Cidade>> GetAllAsync();


    Task<Cidade?> GetByIdAsync(int id);


    Task<Cidade> CreateAsync(Cidade cidade);


    Task UpdateAsync(Cidade cidade);


    Task DeleteAsync(Cidade cidade);

}