namespace CadastroCarnes.Model.DTOs;

using CadastroCarnes.Model.Enums;

public class CarneDto
{
    public string Descricao { get; set; } = string.Empty;

    public OrigemCarne Origem { get; set; }
}