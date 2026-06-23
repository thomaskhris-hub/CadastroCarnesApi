using CadastroCarnes.Model.DTOs;

namespace CadastroCarnes.Service.Interfaces;

public interface IMoedaService
{
    Task<CotacaoMoedaDto> BuscarCotacao(
        string moeda
    );
}