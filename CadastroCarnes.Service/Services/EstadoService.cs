using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;


namespace CadastroCarnes.Service.Services;


public class EstadoService : IEstadoService
{

    private readonly IEstadoRepository _repository;


    public EstadoService(IEstadoRepository repository)
    {
        _repository = repository;
    }



    public async Task<List<Estado>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }



    public async Task<Estado?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }



    public async Task<Estado> CreateAsync(Estado estado)
    {
        await _repository.AddAsync(estado);

        return estado;
    }



    public async Task UpdateAsync(Estado estado)
    {
        await _repository.UpdateAsync(estado);
    }



    public async Task DeleteAsync(Estado estado)
    {
        await _repository.DeleteAsync(estado);
    }

}