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
  private CadastroService _cadastroService;

  public UsuarioController(CadastroService cadastroService)
  {
    _cadastroService = cadastroService;
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto userDto)
  {
    await _cadastroService.Cadastro(userDto);
    return Ok("Usuario cadastrado com sucesso!");
  }
}
