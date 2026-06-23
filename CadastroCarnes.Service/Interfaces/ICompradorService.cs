using CadastroCarnes.Model.Entities;

namespace CadastroCarnes.Service.Interfaces;

public interface ICompradorService
{
    Task<List<Comprador>> GetAllAsync();

    Task<Comprador?> GetByIdAsync(int id);

    Task<Comprador> CreateAsync(Comprador comprador);

    Task<bool> UpdateAsync(int id, Comprador comprador);

    Task<bool> DeleteAsync(int id);
}