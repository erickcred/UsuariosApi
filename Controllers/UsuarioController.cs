using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs.UsuarioDto;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  private UsuarioService _usuarioService;

  public UsuarioController(UsuarioService usuarioService)
  {
    _usuarioService = usuarioService;
  }

  [HttpPost("cadastro")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto userDto)
  {
    await _usuarioService.Cadastro(userDto);
    return Ok("Usuario cadastrado com sucesso!");
  }

  [HttpPost("login")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> Login(LoginUsuarioDto dto)
  {
    var result = await _usuarioService.Login(dto);
    return Ok(result);
  }
}
