using CadastroCarnes.Model.DTOs;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCarnes.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarnesController : ControllerBase
{
    private readonly ICarneService _service;


    public CarnesController(ICarneService service)
    {
        _service = service;
    }



    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var carnes = await _service.GetAllAsync();

        return Ok(carnes);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var carne = await _service.GetByIdAsync(id);


        if (carne == null)
            return NotFound();


        return Ok(carne);
    }



    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CarneDto dto)
    {
        var carne = new Carne
        {
            Descricao = dto.Descricao,
            Origem = dto.Origem
        };


        var criada = await _service.CreateAsync(carne);


        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = criada.Id },
            criada
        );
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        int id,
        [FromBody] CarneDto dto)
    {
        var carne = new Carne
        {
            Descricao = dto.Descricao,
            Origem = dto.Origem
        };


        var atualizado = await _service.UpdateAsync(id, carne);


        if (!atualizado)
            return NotFound();


        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var excluido = await _service.DeleteAsync(id);


            if (!excluido)
                return NotFound();


            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}