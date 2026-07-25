using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ControleGastos.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace ControleGastos.API.Authentication;

// Serviço responsável pela geração do token JWT.
public class JwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Gera um token JWT para o usuário autenticado.
    public string GerarToken(Usuario usuario)
    {
        // Define as informações que serão armazenadas no token.
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Perfil)
        };

        // Cria a chave e as credenciais de assinatura do token.
        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var credenciais = new SigningCredentials(
            chave,
            SecurityAlgorithms.HmacSha256);

        // Monta o token JWT.
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credenciais);

        // Retorna o token em formato de texto.
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}