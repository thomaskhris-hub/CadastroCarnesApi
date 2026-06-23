using CadastroCarnes.Model.DTOs;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CadastroCarnes.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CidadesController : ControllerBase
{

    private readonly ICidadeService _service;


    public CidadesController(ICidadeService service)
    {
        _service = service;
    }





    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var cidades = await _service.GetAllAsync();

        return Ok(cidades);
    }







    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var cidade = await _service.GetByIdAsync(id);


        if (cidade == null)
            return NotFound();


        return Ok(cidade);
    }







    [HttpPost]
    public async Task<IActionResult> Criar(
        [FromBody] CidadeDto dto)
    {

        var cidade = new Cidade
        {
            Nome = dto.Nome,
            EstadoId = dto.EstadoId
        };


        var criada = await _service.CreateAsync(cidade);


        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = criada.Id },
            criada
        );

    }








    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        int id,
        [FromBody] CidadeDto dto)
    {


        var cidade = await _service.GetByIdAsync(id);


        if (cidade == null)
            return NotFound();



        cidade.Nome = dto.Nome;

        cidade.EstadoId = dto.EstadoId;



        await _service.UpdateAsync(cidade);



        return NoContent();

    }








    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {


        var cidade = await _service.GetByIdAsync(id);


        if (cidade == null)
            return NotFound();



        await _service.DeleteAsync(cidade);



        return NoContent();

    }


}