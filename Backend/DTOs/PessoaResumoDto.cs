namespace ControleGastos.API.DTOs;

// DTO utilizado para retornar o resumo financeiro de cada pessoa.

public class PessoaResumoDto
{
    public string Nome { get; set; } = "";

    public decimal Receitas { get; set; }

    public decimal Despesas { get; set; }

    public decimal Saldo { get; set; }
}