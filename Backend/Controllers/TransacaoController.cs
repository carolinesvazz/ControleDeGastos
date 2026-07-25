using Microsoft.AspNetCore.Authorization;
using ControleGastos.API.Models;
using ControleGastos.API.DTOs;
using ControleGastos.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers;

// Controller responsável pelo gerenciamento de transações

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TransacaoController : ControllerBase
{
    private readonly TransacaoService _service;

    public TransacaoController(TransacaoService service)
    {
        _service = service;
    }

    // POST api/transacao
    [HttpPost]
    public async Task<ActionResult> Criar(CriarTransacaoDto dto)
    {
        try
        {
            var transacao = await _service.CriarAsync(dto);

            return CreatedAtAction(
                nameof(Listar),
                new { id = transacao.Id },
                transacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET api/transacao
[HttpGet]
public async Task<ActionResult> Listar(
    int pagina = 1,
    int tamanhoPagina = 10)
{
    var transacoes = await _service.ListarAsync(
        pagina,
        tamanhoPagina);

    return Ok(transacoes);
}

    // GET api/transacao/pessoa/1
    [HttpGet("pessoa/{pessoaId}")]
    public async Task<ActionResult> ListarPorPessoa(int pessoaId)
    {
        var transacoes = await _service.ListarPorPessoaAsync(pessoaId);

        return Ok(transacoes);
    }

    // Lista as transações por tipo (Receita ou Despesa)

    [HttpGet("tipo/{tipo}")]
public async Task<ActionResult> ListarPorTipo(TipoTransacao tipo)
{
    var transacoes = await _service.ListarPorTipoAsync(tipo);

    return Ok(transacoes);
}

// Busca transações pela descrição

[HttpGet("buscar")]
public async Task<ActionResult> Buscar(string descricao)
{
    var resultado = await _service.BuscarDescricaoAsync(descricao);

    return Ok(resultado);
}

// Lista transações com valor igual ou superior ao informado

[HttpGet("valor-minimo")]
public async Task<ActionResult> ValorMinimo(decimal valor)
{
    return Ok(await _service.ValorMinimoAsync(valor));
}

    // DELETE api/transacao/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        var sucesso = await _service.ExcluirAsync(id);

        if (!sucesso)
            return NotFound("Transação não encontrada.");

        return NoContent();
    }
}