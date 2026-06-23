using CadastroCarnes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CadastroCarnes.Controllers;


[ApiController]
[Route("api/moedas")]
public class MoedaController : ControllerBase
{

    private readonly IMoedaService _moedaService;



    public MoedaController(
        IMoedaService moedaService
    )
    {
        _moedaService = moedaService;
    }




    [HttpGet("{moeda}")]
    public async Task<IActionResult> Get(
        string moeda
    )
    {

        var resultado =
            await _moedaService
            .BuscarCotacao(moeda);



        return Ok(resultado);

    }

}