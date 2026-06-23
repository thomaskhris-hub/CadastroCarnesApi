using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;


namespace CadastroCarnes.Service.Services;


public class CidadeService : ICidadeService
{

    private readonly ICidadeRepository _repository;


    public CidadeService(ICidadeRepository repository)
    {
        _repository = repository;
    }



    public async Task<List<Cidade>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }




    public async Task<Cidade?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }




    public async Task<Cidade> CreateAsync(Cidade cidade)
    {
        await _repository.AddAsync(cidade);

        return cidade;
    }





    public async Task UpdateAsync(Cidade cidade)
    {
        await _repository.UpdateAsync(cidade);
    }





    public async Task DeleteAsync(Cidade cidade)
    {
        await _repository.DeleteAsync(cidade);
    }

}