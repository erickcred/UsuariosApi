using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsuariosApi.Authorization;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UsuarioDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Configuração do Identity 
builder.Services // https://learn.microsoft.com/pt-br/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-7.0#password
  .AddIdentity<Usuario, IdentityRole>()
  .AddEntityFrameworkStores<UsuarioDbContext>()
  .AddDefaultTokenProviders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = true, // validação da chave gerada para o Token
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("@#$@#fdsasd{}__+211_*&¨sfddfsdfsdfsdds<>Ddsdfdsdf")),
    ValidateAudience = false,
    ValidateIssuer = false,
    ClockSkew = TimeSpan.Zero // ele faz o get ou set do relógio para validação de tempo
  };
});
builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("IdadeMinima", policy =>
  {
    policy.AddRequirements(new IdadeMinima(18));
  });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
