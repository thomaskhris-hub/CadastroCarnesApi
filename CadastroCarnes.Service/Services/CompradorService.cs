using CadastroCarnes.Data.Repositories.Interfaces;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;

namespace CadastroCarnes.Service.Services;

public class CompradorService : ICompradorService
{
    private readonly ICompradorRepository _repository;


    public CompradorService(ICompradorRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<Comprador>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }


    public async Task<Comprador?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }


    public async Task<Comprador> CreateAsync(Comprador comprador)
    {
        Validar(comprador);

        await _repository.AddAsync(comprador);

        return comprador;
    }


    public async Task<bool> UpdateAsync(int id, Comprador comprador)
    {
        var existente = await _repository.GetByIdAsync(id);

        if (existente == null)
            return false;


        Validar(comprador);


        existente.Nome = comprador.Nome;
        existente.Documento = comprador.Documento;
        existente.CidadeId = comprador.CidadeId;


        await _repository.UpdateAsync(existente);

        return true;
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var comprador = await _repository.GetByIdAsync(id);

        if (comprador == null)
            return false;


        var possuiPedidos = await _repository.HasPedidosAsync(id);

        if (possuiPedidos)
        {
            throw new Exception(
                "Não é possível excluir comprador com pedidos vinculados."
            );
        }


        await _repository.DeleteAsync(comprador);

        return true;
    }


    private void Validar(Comprador comprador)
    {
        if (string.IsNullOrWhiteSpace(comprador.Nome))
            throw new Exception("Nome do comprador é obrigatório.");


        if (string.IsNullOrWhiteSpace(comprador.Documento))
            throw new Exception("Documento do comprador é obrigatório.");
    }
}