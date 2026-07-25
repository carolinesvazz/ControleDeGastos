// DTO utilizado para retornar o resumo financeiro geral do sistema.

public class DashboardDto
{
    public int TotalPessoas { get; set; }

    public int TotalTransacoes { get; set; }

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal Saldo { get; set; }
}