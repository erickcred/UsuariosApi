
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class TokenService
{
  private IConfiguration _config;

  public TokenService(IConfiguration config)
    => _config = config;

  public string GenerateToken(Usuario usuario)
  {
    Claim[] claims = new Claim[]
    {
      new Claim("username", usuario.UserName),
      new Claim("id", usuario.Id),
      new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
      new Claim(ClaimTypes.Name, usuario.UserName),
    };

    var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SymmetricSecurityKey"]));

    var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

    var geraToken = new JwtSecurityToken(
      expires: DateTime.Now.AddDays(1),
      claims: claims,
      signingCredentials: signingCredentials);

    string token = new JwtSecurityTokenHandler().WriteToken(geraToken);

    return token;
  }
}