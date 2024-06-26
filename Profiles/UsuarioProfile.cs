﻿using AutoMapper;
using UsuariosApi.Data.DTOs.UsuarioDto;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles;

public class UsuarioProfile : Profile
{
  public UsuarioProfile()
  {
    CreateMap<CreateUsuarioDto, Usuario>();
  }
}
