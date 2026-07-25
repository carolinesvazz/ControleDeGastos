using ControleGastos.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers;

// Controller responsável pelas consultas do Dashboard

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly DashboardService _service;

    public DashboardController(DashboardService service)
    {
        _service = service;
    }

    // Retorna o resumo geral do sistema
    [HttpGet]
    public async Task<ActionResult> ObterResumo()
    {
        try
        {
            var resumo = await _service.ObterResumoAsync();
            return Ok(resumo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                mensagem = ex.Message,
                stack = ex.StackTrace
            });
        }
    }

    // Retorna o resumo financeiro de cada pessoa
    [HttpGet("por-pessoa")]
    public async Task<ActionResult> ResumoPorPessoa()
    {
        try
        {
            var pessoas = await _service.ObterResumoPorPessoaAsync();
            return Ok(pessoas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                mensagem = ex.Message,
                stack = ex.StackTrace
            });
        }
    }
}