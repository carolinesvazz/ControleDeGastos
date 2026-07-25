using System.ComponentModel.DataAnnotations;

namespace ControleGastos.API.DTOs;

/// <------->
/// Dados necessários para cadastrar uma pessoa.
/// </------>
public class CriarPessoaDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

[Range(1, 120, ErrorMessage = "A idade deve ser maior que zero.")]
public int Idade { get; set; }
}