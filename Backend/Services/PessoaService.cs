// Cria uma nova pessoa no banco de dados

using ControleGastos.API.Data;
using ControleGastos.API.DTOs;
using ControleGastos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services;

public class PessoaService
{
private readonly AppDbContext _context;

public PessoaService(AppDbContext context)
{
    _context = context;
}

public async Task<Pessoa> CriarAsync(CriarPessoaDto dto)
{
    var pessoa = new Pessoa
    {
        Nome = dto.Nome,
        Idade = dto.Idade
    };

    _context.Pessoas.Add(pessoa);

    await _context.SaveChangesAsync();

    return pessoa;
    }

    public async Task<List<Pessoa>> ListarAsync()
{
    return await _context.Pessoas.ToListAsync();
}

public async Task<Pessoa?> AtualizarAsync(int id, CriarPessoaDto dto)
{
    var pessoa = await _context.Pessoas.FindAsync(id);

    if (pessoa == null)
        return null;

    pessoa.Nome = dto.Nome;
    pessoa.Idade = dto.Idade;

    await _context.SaveChangesAsync();

    return pessoa;
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
    // Procura a pessoa
    var pessoa = await _context.Pessoas.FindAsync(id);

    if (pessoa == null)
        return false;

    // Busca todas as transações dessa pessoa
    var transacoes = await _context.Transacoes
        .Where(t => t.PessoaId == id)
        .ToListAsync();

    // Remove todas as transações
    _context.Transacoes.RemoveRange(transacoes);

    // Remove a pessoa
    _context.Pessoas.Remove(pessoa);

    await _context.SaveChangesAsync();

    return true;
}

}
