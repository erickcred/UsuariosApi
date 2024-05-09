using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.DTOs.UsuarioDto;

public class LoginUsuarioDto
{
  [Required(ErrorMessage = "O nome de usuário deve ser informado!")]
  public string UserName { get; set; }
  [Required(ErrorMessage = "A senha do usuário deve ser informada!")]
  public string Password { get; set; }
}
