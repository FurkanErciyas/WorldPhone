﻿using ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class SmartPhone : BaseEntity
    {
        [Required]
        public string? Model { get; set; }

        public double ScreenSize { get; set; }

        [Required, MaxLength(50)]
        public string? ScreenDurability { get; set; }

        [Required, MaxLength(50)]
        public string? ScreenTechnology { get; set; }

        [Required, MaxLength(50)]
        public string? ScreenResolution { get; set; }

        public int PixelDensity { get; set; }
        public int BatteryCapacity { get; set; }
        public int ChargePower { get; set; }
        public int BackCameraResolution { get; set; }
        public int FrontCameraResolution { get; set; }

        [Required, MaxLength(100)]
        public string? Chipset { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Thickness { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        public ChargeTypeEnum ChargeType { get; set; }
        public int InternalStorage { get; set; }
        public OS OS { get; set; }
        public int RAM { get; set; }
        public decimal Price { get; set; }
        public string PicturePath { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
