using ControleGastos.API.Data;
using ControleGastos.API.DTOs;
using ControleGastos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services;

// Verifica se a pessoa existe antes de cadastrar a transação

public class TransacaoService
{
    private readonly AppDbContext _context;

    public TransacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Transacao> CriarAsync(CriarTransacaoDto dto)
{
    // Verifica se a pessoa existe
    var pessoa = await _context.Pessoas
        .FirstOrDefaultAsync(p => p.Id == dto.PessoaId);

    if (pessoa == null)
        throw new Exception("Pessoa não encontrada.");

    if (pessoa.Idade < 18 && dto.Tipo == TipoTransacao.Receita)
    {
        throw new Exception("Menores de idade só podem cadastrar despesas.");
    }

    var transacao = new Transacao
    {
        Descricao = dto.Descricao,
        Valor = dto.Valor,
        Tipo = dto.Tipo,
        PessoaId = dto.PessoaId
    };

    _context.Transacoes.Add(transacao);

    await _context.SaveChangesAsync();

    return transacao;
    }

public async Task<List<Transacao>> ListarAsync(int pagina, int tamanhoPagina)
{
    return await _context.Transacoes
        .Include(t => t.Pessoa)
        .Skip((pagina - 1) * tamanhoPagina)
        .Take(tamanhoPagina)
        .ToListAsync();
}

public async Task<List<Transacao>> ListarPorPessoaAsync(int pessoaId)
{
    return await _context.Transacoes
        .Where(t => t.PessoaId == pessoaId)
        .Include(t => t.Pessoa)
        .ToListAsync();
}

public async Task<List<Transacao>> ListarPorTipoAsync(TipoTransacao tipo)
{
    return await _context.Transacoes
        .Where(t => t.Tipo == tipo)
        .Include(t => t.Pessoa)
        .ToListAsync();
}

public async Task<List<Transacao>> ValorMinimoAsync(decimal valor)
{
    return await _context.Transacoes
        .Where(t => t.Valor >= valor)
        .Include(t => t.Pessoa)
        .ToListAsync();
}

public async Task<List<Transacao>> BuscarDescricaoAsync(string descricao)
{
    return await _context.Transacoes
        .Where(t => t.Descricao.Contains(descricao))
        .Include(t => t.Pessoa)
        .ToListAsync();
}

public async Task<bool> ExcluirAsync(int id)
{
    var transacao = await _context.Transacoes.FindAsync(id);

    if (transacao == null)
        return false;

    _context.Transacoes.Remove(transacao);

    await _context.SaveChangesAsync();

    return true;
}

}