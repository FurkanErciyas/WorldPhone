using AutoMapper;
using ENTITIES.DTOS.PhoneDTO;
using ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Profiles
{
    public class PhoneProfile : Profile
    {
        public PhoneProfile()
        {
            CreateMap<AddPhoneDTO, SmartPhone>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.ScreenSize, opt => opt.MapFrom(src => src.ScreenSize))
                .ForMember(dest => dest.ScreenDurability, opt => opt.MapFrom(src => src.ScreenDurability))
                .ForMember(dest => dest.ScreenTechnology, opt => opt.MapFrom(src => src.ScreenTechnology))
                .ForMember(dest => dest.ScreenResolution, opt => opt.MapFrom(src => src.ScreenResolution))
                .ForMember(dest => dest.PixelDensity, opt => opt.MapFrom(src => src.PixelDensity))
                .ForMember(dest => dest.BatteryCapacity, opt => opt.MapFrom(src => src.BatteryCapacity))
                .ForMember(dest => dest.ChargePower, opt => opt.MapFrom(src => src.ChargePower))
                .ForMember(dest => dest.BackCameraResolution, opt => opt.MapFrom(src => src.BackCameraResolution))
                .ForMember(dest => dest.FrontCameraResolution, opt => opt.MapFrom(src => src.FrontCameraResolution))
                .ForMember(dest => dest.Chipset, opt => opt.MapFrom(src => src.Chipset))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Thickness, opt => opt.MapFrom(src => src.Thickness))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.ChargeType, opt => opt.MapFrom(src => src.ChargeType))
                .ForMember(dest => dest.InternalStorage, opt => opt.MapFrom(src => src.InternalStorage))
                .ForMember(dest => dest.OS, opt => opt.MapFrom(src => src.OS))
                .ForMember(dest => dest.RAM, opt => opt.MapFrom(src => src.RAM))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<EditPhoneDTO, SmartPhone>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.ScreenSize, opt => opt.MapFrom(src => src.ScreenSize))
                .ForMember(dest => dest.ScreenDurability, opt => opt.MapFrom(src => src.ScreenDurability))
                .ForMember(dest => dest.ScreenTechnology, opt => opt.MapFrom(src => src.ScreenTechnology))
                .ForMember(dest => dest.ScreenResolution, opt => opt.MapFrom(src => src.ScreenResolution))
                .ForMember(dest => dest.PixelDensity, opt => opt.MapFrom(src => src.PixelDensity))
                .ForMember(dest => dest.BatteryCapacity, opt => opt.MapFrom(src => src.BatteryCapacity))
                .ForMember(dest => dest.ChargePower, opt => opt.MapFrom(src => src.ChargePower))
                .ForMember(dest => dest.BackCameraResolution, opt => opt.MapFrom(src => src.BackCameraResolution))
                .ForMember(dest => dest.FrontCameraResolution, opt => opt.MapFrom(src => src.FrontCameraResolution))
                .ForMember(dest => dest.Chipset, opt => opt.MapFrom(src => src.Chipset))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Thickness, opt => opt.MapFrom(src => src.Thickness))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.ChargeType, opt => opt.MapFrom(src => src.ChargeType))
                .ForMember(dest => dest.InternalStorage, opt => opt.MapFrom(src => src.InternalStorage))
                .ForMember(dest => dest.OS, opt => opt.MapFrom(src => src.OS))
                .ForMember(dest => dest.RAM, opt => opt.MapFrom(src => src.RAM))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.PicturePath, opt => opt.MapFrom(src => src.PicturePath));

            CreateMap<SmartPhone, EditPhoneDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.ScreenSize, opt => opt.MapFrom(src => src.ScreenSize))
                .ForMember(dest => dest.ScreenDurability, opt => opt.MapFrom(src => src.ScreenDurability))
                .ForMember(dest => dest.ScreenTechnology, opt => opt.MapFrom(src => src.ScreenTechnology))
                .ForMember(dest => dest.ScreenResolution, opt => opt.MapFrom(src => src.ScreenResolution))
                .ForMember(dest => dest.PixelDensity, opt => opt.MapFrom(src => src.PixelDensity))
                .ForMember(dest => dest.BatteryCapacity, opt => opt.MapFrom(src => src.BatteryCapacity))
                .ForMember(dest => dest.ChargePower, opt => opt.MapFrom(src => src.ChargePower))
                .ForMember(dest => dest.BackCameraResolution, opt => opt.MapFrom(src => src.BackCameraResolution))
                .ForMember(dest => dest.FrontCameraResolution, opt => opt.MapFrom(src => src.FrontCameraResolution))
                .ForMember(dest => dest.Chipset, opt => opt.MapFrom(src => src.Chipset))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Thickness, opt => opt.MapFrom(src => src.Thickness))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.ChargeType, opt => opt.MapFrom(src => src.ChargeType))
                .ForMember(dest => dest.InternalStorage, opt => opt.MapFrom(src => src.InternalStorage))
                .ForMember(dest => dest.OS, opt => opt.MapFrom(src => src.OS))
                .ForMember(dest => dest.RAM, opt => opt.MapFrom(src => src.RAM))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.PicturePath, opt => opt.MapFrom(src => src.PicturePath));
        }
    }
}
