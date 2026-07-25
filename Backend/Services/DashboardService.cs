using ControleGastos.API.Data;
using ControleGastos.API.DTOs;
using ControleGastos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services;

/// Serviço responsável pelos cálculos e consultas do Dashboard.
public class DashboardService
{
    private readonly AppDbContext _context;

    public DashboardService(AppDbContext context)
    {
        _context = context;
    }

    // Resumo geral do sistema
   public async Task<DashboardDto> ObterResumoAsync()
{
    // Busca todas as transações primeiro
    var transacoes = await _context.Transacoes.ToListAsync();

    // Faz os cálculos em memória
    var receitas = transacoes
        .Where(t => t.Tipo == TipoTransacao.Receita)
        .Sum(t => t.Valor);

    var despesas = transacoes
        .Where(t => t.Tipo == TipoTransacao.Despesa)
        .Sum(t => t.Valor);

    return new DashboardDto
    {
        TotalPessoas = await _context.Pessoas.CountAsync(),
        TotalTransacoes = transacoes.Count,
        TotalReceitas = receitas,
        TotalDespesas = despesas,
        Saldo = receitas - despesas
    };
}

    // Resumo financeiro por pessoa
public async Task<List<PessoaResumoDto>> ObterResumoPorPessoaAsync()
{
    // Carrega todas as pessoas e suas transações na memória
    var pessoas = await _context.Pessoas
        .Include(p => p.Transacoes)
        .ToListAsync();

    // Agora faz os cálculos em memória (LINQ to Objects)
    return pessoas.Select(p => new PessoaResumoDto
    {
        Nome = p.Nome,

        Receitas = p.Transacoes
            .Where(t => t.Tipo == TipoTransacao.Receita)
            .Sum(t => t.Valor),

        Despesas = p.Transacoes
            .Where(t => t.Tipo == TipoTransacao.Despesa)
            .Sum(t => t.Valor),

        Saldo =
            p.Transacoes
                .Where(t => t.Tipo == TipoTransacao.Receita)
                .Sum(t => t.Valor)
            -
            p.Transacoes
                .Where(t => t.Tipo == TipoTransacao.Despesa)
                .Sum(t => t.Valor)
    }).ToList();
    }
}