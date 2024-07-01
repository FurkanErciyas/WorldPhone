using AutoMapper;
using ENTITIES.DTOS.BrandDTO;
using ENTITIES.DTOS.PhoneDTO;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddBrandDTO, Brand>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName));
        }
    }
}
