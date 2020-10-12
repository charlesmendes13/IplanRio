using AutoMapper;
using IplanRio.Application.DTO;
using IplanRio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Application.AutoMapper
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<ShoppingDTO, Shopping>();
            CreateMap<Shopping, ShoppingDTO>();
        }
    }
}
