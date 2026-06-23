using CadastroCarnes.Model.DTOs;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CadastroCarnes.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EstadosController : ControllerBase
{

    private readonly IEstadoService _service;


    public EstadosController(IEstadoService service)
    {
        _service = service;
    }





    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var estados = await _service.GetAllAsync();

        return Ok(estados);
    }






    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {

        var estado = await _service.GetByIdAsync(id);


        if(estado == null)
            return NotFound();


        return Ok(estado);

    }







    [HttpPost]
    public async Task<IActionResult> Criar(
        EstadoDto dto)
    {


        var estado = new Estado
        {
            Nome = dto.Nome,
            UF = dto.Sigla
        };


        var criado =
            await _service.CreateAsync(estado);



        return CreatedAtAction(
            nameof(BuscarPorId),
            new {id = criado.Id},
            criado
        );

    }








    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        int id,
        EstadoDto dto)
    {


        var estado =
            await _service.GetByIdAsync(id);



        if(estado == null)
            return NotFound();




        estado.Nome = dto.Nome;

        estado.UF = dto.Sigla;




        await _service.UpdateAsync(estado);



        return NoContent();

    }








    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {

        var estado =
            await _service.GetByIdAsync(id);



        if(estado == null)
            return NotFound();



        await _service.DeleteAsync(estado);



        return NoContent();

    }

}