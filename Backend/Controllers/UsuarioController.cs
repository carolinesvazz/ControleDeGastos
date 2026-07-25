using ControleGastos.API.Authentication;
using ControleGastos.API.DTOs;
using ControleGastos.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers;

// Controller responsável pela autenticação de usuários

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;
    private readonly JwtService _jwtService;

    public UsuarioController(
        UsuarioService usuarioService,
        JwtService jwtService)
    {
        _usuarioService = usuarioService;
        _jwtService = jwtService;
    }

    // Realiza o login e gera um token JWT

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var usuario = await _usuarioService.LoginAsync(dto.Email, dto.Senha);

        if (usuario == null)
            return Unauthorized("Email ou senha inválidos.");

        var token = _jwtService.GerarToken(usuario);

        return Ok(new
        {
            token
        });
    }

    // Cadastra um novo usuário

    [HttpPost("registrar")]
public async Task<IActionResult> Registrar(CriarUsuarioDto dto)
{
    var usuario = await _usuarioService.CriarAsync(dto);

    return CreatedAtAction(
        nameof(Registrar),
        new { id = usuario.Id },
        usuario);
}
}