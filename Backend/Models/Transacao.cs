namespace ControleGastos.API.Models;

/// <-------->
/// Representa uma transação financeira.
/// </------->
public class Transacao
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    // Chave estrangeira
    public int PessoaId { get; set; }

    // Pessoa à qual esta transação pertence
    public Pessoa Pessoa { get; set; } = null!;
}