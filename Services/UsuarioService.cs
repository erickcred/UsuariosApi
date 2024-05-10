using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.DTOs.UsuarioDto;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class UsuarioService
{
  private readonly IMapper _autoMapper;
  private readonly UserManager<Usuario> _userManager;
  private readonly SignInManager<Usuario> _sigInManager;
  private readonly TokenService _tokenService;

  public UsuarioService(
    IMapper autoMapper,
    UserManager<Usuario> userManager,
    SignInManager<Usuario> sigInManager,
    TokenService tokenService)
  {
    _autoMapper = autoMapper;
    _userManager = userManager;
    _sigInManager = sigInManager;
    _tokenService = tokenService;
  }

  public async Task Cadastro(CreateUsuarioDto userDto)
  {
    Usuario usuario = _autoMapper.Map<Usuario>(userDto);
    IdentityResult resultado = await _userManager.CreateAsync(usuario, userDto.Password);

    if (!resultado.Succeeded)
      throw new ApplicationException($"Falha ao cadastrar usuário!\n\n{resultado}");
  }

  public async Task<string> Login(LoginUsuarioDto dtoLogin)
  {
    var resultado = await _sigInManager.PasswordSignInAsync(dtoLogin.UserName, dtoLogin.Password, true, false);

    if (!resultado.Succeeded)
      throw new ApplicationException("Usuário não autenticado!");

    var usuario = _sigInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dtoLogin.UserName.ToUpper());

    var token = _tokenService.GenerateToken(usuario);
    return token;
  }
}
