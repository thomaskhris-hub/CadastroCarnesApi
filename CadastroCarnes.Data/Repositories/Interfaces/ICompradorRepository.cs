using CadastroCarnes.Model.Entities;

namespace CadastroCarnes.Data.Repositories.Interfaces;

public interface ICompradorRepository
{
    Task<List<Comprador>> GetAllAsync();

    Task<Comprador?> GetByIdAsync(int id);

    Task AddAsync(Comprador comprador);

    Task UpdateAsync(Comprador comprador);

    Task DeleteAsync(Comprador comprador);

    Task<bool> HasPedidosAsync(int compradorId);
}