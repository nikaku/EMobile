using AutoMapper;
using EMobile.BL.Dtos.MobileSpecDtos;
using EMobile.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL.AutoMapperProfiles
{
    public class MobileSpecProfile : Profile
    {
        public MobileSpecProfile()
        {
            CreateMap<MobileSpecCreateDto, MobileSpec>();
            CreateMap<MobileSpec, MobileSpecGetDto>();
        }
    }
}
