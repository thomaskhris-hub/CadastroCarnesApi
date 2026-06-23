using System.Text.Json;
using CadastroCarnes.Model.DTOs;
using CadastroCarnes.Service.Interfaces;


namespace CadastroCarnes.Service.Services;


public class MoedaService : IMoedaService
{

    private readonly HttpClient _httpClient;


    public MoedaService(
        HttpClient httpClient
    )
    {
        _httpClient = httpClient;
    }



    public async Task<CotacaoMoedaDto> BuscarCotacao(
        string moeda
    )
    {

        moeda = moeda.ToUpper();


        var url =
            $"https://economia.awesomeapi.com.br/json/last/{moeda}-BRL";


        var response =
            await _httpClient.GetAsync(url);



        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                "Erro ao consultar cotação"
            );
        }



        var json =
            await response.Content.ReadAsStringAsync();



        using var document =
            JsonDocument.Parse(json);



        var dados =
            document.RootElement
            .GetProperty($"{moeda}BRL");



        var valor =
            decimal.Parse(
                dados
                .GetProperty("bid")
                .GetString()!
            );



        return new CotacaoMoedaDto
        {
            Moeda = moeda,
            Valor = valor,
            DataConsulta = DateTime.Now
        };

    }
}