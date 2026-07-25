using Microsoft.EntityFrameworkCore;
using ControleGastos.API.Models;


namespace ControleGastos.API.Data;

/// <-------->
/// Contexto do banco de dados.
/// Responsável por mapear as entidades para tabelas do SQLite.
/// </------->
public class AppDbContext : DbContext
{
    // Construtor que recebe as configurações do banco.
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Tabela Pessoas
    public DbSet<Pessoa> Pessoas { get; set; }

    // Tabela Transações
    public DbSet<Transacao> Transacoes { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }
}