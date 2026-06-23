namespace CadastroCarnes.Model.DTOs;

public class CotacaoMoedaDto
{
    public string Moeda { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public DateTime DataConsulta { get; set; }
}