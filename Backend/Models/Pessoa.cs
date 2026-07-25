namespace ControleGastos.API.Models;

/// <-------->
/// Representa uma pessoa cadastrada no sistema.
/// </------->
public class Pessoa
{

/// Identificador único da pessoa.
    public int Id { get; set; }

    /// Nome da pessoa.
    public string Nome { get; set; } = string.Empty;

    /// Idade da pessoa.
    public int Idade { get; set; }

    /// Transações associadas à pessoa.
    public List<Transacao> Transacoes { get; set; } = new();
}