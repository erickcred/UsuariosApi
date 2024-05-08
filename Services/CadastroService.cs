using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.DTOs.UsuarioDto;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
  public class CadastroService
  {
    private readonly IMapper _autoMapper;
    private readonly UserManager<Usuario> _userManager;

    public CadastroService(IMapper autoMapper, UserManager<Usuario> userManager)
    {
      _autoMapper = autoMapper;
      _userManager = userManager;
    }

    public async Task Cadastro(CreateUsuarioDto userDto)
    {
      Usuario usuario = _autoMapper.Map<Usuario>(userDto);
      IdentityResult resultado = await _userManager.CreateAsync(usuario, userDto.Password);

      if (!resultado.Succeeded)
        throw new ApplicationException($"Falha ao cadastrar usuário!\n\n{resultado}");
    }
  }
}
