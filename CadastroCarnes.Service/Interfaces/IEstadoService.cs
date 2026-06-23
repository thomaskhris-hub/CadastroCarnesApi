using CadastroCarnes.Model.Entities;


namespace CadastroCarnes.Service.Interfaces;


public interface IEstadoService
{

    Task<List<Estado>> GetAllAsync();


    Task<Estado?> GetByIdAsync(int id);


    Task<Estado> CreateAsync(Estado estado);


    Task UpdateAsync(Estado estado);


    Task DeleteAsync(Estado estado);

}