using CadastroCarnes.Model.DTOs;
using CadastroCarnes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCarnes.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _service;

    public PedidosController(IPedidoService service)
    {
        _service = service;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var pedido = await _service.ObterPorId(id);


        if (pedido == null)
            return NotFound();


        return Ok(pedido);
    }



    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] PedidoDto dto)
    {
        var id = await _service.CriarPedido(dto);


        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id },
            dto
        );
    }



    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var pedidos = await _service.ListarPedidos();

        return Ok(pedidos);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] PedidoDto dto)
    {
        var atualizado = await _service.AtualizarPedido(id, dto);


        if (!atualizado)
            return NotFound();


        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var excluido = await _service.ExcluirPedido(id);


        if (!excluido)
            return NotFound();


        return NoContent();
    }
}