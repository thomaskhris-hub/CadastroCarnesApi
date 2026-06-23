using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;

namespace CadastroCarnes.Service.Services;

public class CarneService : ICarneService
{
    private readonly ICarneRepository _repository;


    public CarneService(ICarneRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<Carne>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }


    public async Task<Carne?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }


    public async Task<Carne> CreateAsync(Carne carne)
    {
        if (string.IsNullOrWhiteSpace(carne.Descricao))
        {
            throw new Exception("A descrição da carne é obrigatória.");
        }

        await _repository.AddAsync(carne);

        return carne;
    }


    public async Task<bool> UpdateAsync(int id, Carne carne)
    {
        var existente = await _repository.GetByIdAsync(id);

        if (existente == null)
            return false;


        if (string.IsNullOrWhiteSpace(carne.Descricao))
        {
            throw new Exception("A descrição da carne é obrigatória.");
        }


        existente.Descricao = carne.Descricao;
        existente.Origem = carne.Origem;


        await _repository.UpdateAsync(existente);

        return true;
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var carne = await _repository.GetByIdAsync(id);

        if (carne == null)
            return false;


        var possuiPedidos = await _repository.HasPedidosAsync(id);

        if (possuiPedidos)
        {
            throw new Exception(
                "Não é possível excluir uma carne vinculada a pedidos."
            );
        }


        await _repository.DeleteAsync(carne);

        return true;
    }
}