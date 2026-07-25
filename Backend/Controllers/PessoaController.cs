using Microsoft.AspNetCore.Authorization;
using ControleGastos.API.DTOs;
using ControleGastos.API.Services;
using Microsoft.AspNetCore.Mvc;


namespace ControleGastos.API.Controllers;

// Controller responsável pelo gerenciamento de pessoas

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PessoaController : ControllerBase
{
    private readonly PessoaService _service;

    public PessoaController(PessoaService service)
    {
        _service = service;
    }

    // Cadastra uma nova pessoa

    [HttpPost]
    public async Task<ActionResult> Criar(CriarPessoaDto dto)
    {
        var pessoa = await _service.CriarAsync(dto);

        return CreatedAtAction(
            nameof(Listar),
            new { id = pessoa.Id },
            pessoa);
    }

    // Lista todas as pessoas cadastradas

    [HttpGet]
    public async Task<ActionResult> Listar()
    {
        var pessoas = await _service.ListarAsync();

        return Ok(pessoas);
    }

    // Atualiza os dados de uma pessoa

    [HttpPut("{id}")]
public async Task<ActionResult> Atualizar(int id, CriarPessoaDto dto)
{
    var pessoa = await _service.AtualizarAsync(id, dto);

    if (pessoa == null)
        return NotFound("Pessoa não encontrada.");

    return Ok(pessoa);
    }

    // Remove uma pessoa e suas transações

    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        var sucesso = await _service.ExcluirAsync(id);

        if (!sucesso)
            return NotFound("Pessoa não encontrada.");

        return NoContent();
    }

}