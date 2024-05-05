using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs.UsuarioDto;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  [HttpPost]
  public IActionResult CadastraUsuario(CreateUsuarioDto userDto)
  {
    throw new NotImplementedException();
  }
}
