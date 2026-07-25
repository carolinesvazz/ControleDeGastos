using ControleGastos.API.DTOs;
using ControleGastos.API.Data;
using ControleGastos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services;

// Serviço responsável pelo gerenciamento e autenticação dos usuários.

public class UsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

   // Cadastra um novo usuário no sistema.
    public async Task<Usuario> CriarAsync(CriarUsuarioDto dto)
{
    var usuario = new Usuario
    {
        Nome = dto.Nome,
        Email = dto.Email,
        SenhaHash = dto.SenhaHash,
        Perfil = dto.Perfil
    };

    _context.Usuarios.Add(usuario);

    await _context.SaveChangesAsync();

    return usuario;
}

// Valida o login do usuário por email e senha.
public async Task<Usuario?> LoginAsync(string email, string senha)
{
    return await _context.Usuarios
        .FirstOrDefaultAsync(u =>
            u.Email == email &&
            u.SenhaHash == senha);
    }
}