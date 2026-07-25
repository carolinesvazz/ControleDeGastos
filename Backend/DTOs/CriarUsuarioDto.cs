namespace ControleGastos.API.DTOs;

// DTO utilizado para receber os dados de cadastro de um novo usuário.
public class CriarUsuarioDto
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string SenhaHash { get; set; } = string.Empty;

    public string Perfil { get; set; } = "Usuario";
}