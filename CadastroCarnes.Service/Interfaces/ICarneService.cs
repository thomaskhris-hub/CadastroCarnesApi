using CadastroCarnes.Model.Entities;

namespace CadastroCarnes.Service.Interfaces;

public interface ICarneService
{
    Task<List<Carne>> GetAllAsync();

    Task<Carne?> GetByIdAsync(int id);

    Task<Carne> CreateAsync(Carne carne);

    Task<bool> UpdateAsync(int id, Carne carne);

    Task<bool> DeleteAsync(int id);
}