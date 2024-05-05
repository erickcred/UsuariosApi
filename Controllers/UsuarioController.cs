using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs.UsuarioDto;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  private readonly IMapper _autoMapper;
  private readonly UserManager<Usuario> _userManager;

  public UsuarioController(IMapper autoMapper, UserManager<Usuario> userManager)
  {
    _autoMapper = autoMapper;
    _userManager = userManager;
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto userDto)
  {
    Usuario usuario = _autoMapper.Map<Usuario>(userDto);
    IdentityResult resultado = await _userManager.CreateAsync(usuario, userDto.Password);

    if (resultado.Succeeded) return Ok("Usuário cadastrado");

    throw new ApplicationException("Falha ao cadastrar usuário!");
  }
}
