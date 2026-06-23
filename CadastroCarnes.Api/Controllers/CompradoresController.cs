using CadastroCarnes.Model.DTOs;
using CadastroCarnes.Model.Entities;
using CadastroCarnes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCarnes.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompradoresController : ControllerBase
{
    private readonly ICompradorService _service;


    public CompradoresController(ICompradorService service)
    {
        _service = service;
    }



    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var compradores = await _service.GetAllAsync();

        return Ok(compradores);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var comprador = await _service.GetByIdAsync(id);


        if (comprador == null)
            return NotFound();


        return Ok(comprador);
    }



    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CompradorDto dto)
    {
        var comprador = new Comprador
        {
            Nome = dto.Nome,
            Documento = dto.Documento,
            CidadeId = dto.CidadeId
        };


        var criado = await _service.CreateAsync(comprador);


        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = criado.Id },
            criado
        );
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        int id,
        [FromBody] CompradorDto dto)
    {
        var comprador = new Comprador
        {
            Nome = dto.Nome,
            Documento = dto.Documento,
            CidadeId = dto.CidadeId
        };


        var atualizado = await _service.UpdateAsync(id, comprador);


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