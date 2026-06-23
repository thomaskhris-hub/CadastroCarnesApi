using System.Text.Json.Serialization;


namespace CadastroCarnes.Model.Entities;


public class Cidade
{

    public int Id { get; set; }


    public string Nome { get; set; } = string.Empty;


    public int EstadoId { get; set; }


    [JsonIgnore]
    public Estado? Estado { get; set; }

}