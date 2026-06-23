using CadastroCarnes.Model.Entities;

namespace CadastroCarnes.Data.Repositories.Interfaces;

public interface ICarneRepository
{
    Task<List<Carne>> GetAllAsync();

    Task<Carne?> GetByIdAsync(int id);

    Task AddAsync(Carne carne);

    Task UpdateAsync(Carne carne);

    Task DeleteAsync(Carne carne);

    Task<bool> HasPedidosAsync(int carneId);
}