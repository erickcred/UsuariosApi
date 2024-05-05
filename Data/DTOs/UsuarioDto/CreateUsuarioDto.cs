using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace UsuariosApi.Data.DTOs.UsuarioDto;

public class CreateUsuarioDto
{
  [Required]
  public string UserName { get; set; }
  [Required]
  public DateTime DataNascimento { get; set; }
  [Required]
  [DataType(DataType.Password)]
  public string Password { get; set; }
  [Required]
  [Compare("Password")]
  public string Repassword { get; set; }

}

