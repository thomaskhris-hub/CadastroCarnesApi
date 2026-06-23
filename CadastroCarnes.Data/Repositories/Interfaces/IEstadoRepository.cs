using CadastroCarnes.Model.Entities;


namespace CadastroCarnes.Data.Repositories.Interfaces;


public interface IEstadoRepository
{

    Task<List<Estado>> GetAllAsync();


    Task<Estado?> GetByIdAsync(int id);


    Task AddAsync(Estado estado);


    Task UpdateAsync(Estado estado);


    Task DeleteAsync(Estado estado);

}