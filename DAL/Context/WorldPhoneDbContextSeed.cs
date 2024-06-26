using ENTITIES.Enums;
using ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using WorldPhone.DAL.Context;
using WorldPhone.ENTITIES.Models;

namespace DAL.Context
{
    public static class WorldPhoneDbContextSeed
    {
        public static void Seed(WorldPhoneDbContext db)
        {
            if (db.Brands.Any() || db.SmartPhones.Any()) return;

            var brand_1 = new Brand()
            {
                BrandName = "Apple",
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                UpdatedDate = null,
                DataStatus = DataStatusEnum.Created
            };

            var brand_2 = new Brand()
            {
                BrandName = "Huawei",
                CreatedDate = DateTime.Now,
                DeletedDate = null,
                UpdatedDate = null,
                DataStatus = DataStatusEnum.Created
            };

            db.Brands.AddRange(brand_1, brand_2);
            db.SaveChanges();

            var smartPhone_1 = new SmartPhone()
            {
                Model = "iPhone 13",
                ScreenSize = 6.1,
                ScreenDurability = "Corning Ceramic Shield Glass",
                ScreenTechnology = "OLED",
                ScreenResolution = "1170x2532 (FHD+) Piksel",
                PixelDensity = 460,
                BatteryCapacity = 3227,
                ChargePower = 20,
                BackCameraResolution = 12,
                FrontCameraResolution = 12,
                Chipset = "Apple A15 Bionic",
                Length = 146.7,
                Width = 71.5,
                Thickness = 7.65,
                Weight = 174,
                ChargeType = ChargeTypeEnum.Lightning,
                InternalStorage = 128,
                OS = OS.IOS,
                RAM = 4,
                Price = 36.399m,
                Stock = 9,
                Status = StatusEnum.Active,
                BrandId = 1,

            };

            var smartPhone_2 = new SmartPhone()
            {
                Model = "iPhone 15 Pro Max",
                ScreenSize = 6.7,
                ScreenDurability = "Corning Ceramic Shield Glass",
                ScreenTechnology = "OLED",
                ScreenResolution = "1290x2796 (FHD+) Piksel",
                PixelDensity = 460,
                BatteryCapacity = 4422,
                ChargePower = 20,
                BackCameraResolution = 48,
                FrontCameraResolution = 12,
                Chipset = "Apple A17 Pro",
                Length = 159.9,
                Width = 76.7,
                Thickness = 8.25,
                Weight = 221,
                ChargeType = ChargeTypeEnum.TypeC,
                InternalStorage = 256,
                OS = OS.IOS,
                RAM = 8,
                Price = 71.999m,
                Stock = 14,
                Status = StatusEnum.Active,
                BrandId = 1
            };

            var smartPhone_3 = new SmartPhone()
            {
                Model = "Pura 70 Ultra",
                ScreenSize = 6.8,
                ScreenDurability = "Kunlan Glass",
                ScreenTechnology = "OLED",
                ScreenResolution = "1260x2844 (FHD+) Piksel",
                PixelDensity = 460,
                BatteryCapacity = 5200,
                ChargePower = 100,
                BackCameraResolution = 50,
                FrontCameraResolution = 13,
                Chipset = "Huawei Kirin 9010",
                Length = 162.6,
                Width = 75.1,
                Thickness = 8.4,
                Weight = 226,
                ChargeType = ChargeTypeEnum.TypeC,
                InternalStorage = 512,
                OS = OS.Android,
                RAM = 16,
                Price = 69.999m,
                Stock = 17,
                Status = StatusEnum.Active,
                BrandId = 2
            };

            var smartPhone_4 = new SmartPhone()
            {
                Model = "Mate X3",
                ScreenSize = 6.4,
                ScreenDurability = "Kunlan Glass",
                ScreenTechnology = "OLED",
                ScreenResolution = "1080x2504 (FHD+) Piksel",
                PixelDensity = 426,
                BatteryCapacity = 4800,
                ChargePower = 66,
                BackCameraResolution = 50,
                FrontCameraResolution = 8,
                Chipset = "Qualcomm Snapdragon 8+ Gen 1 (SM8475)",
                Length = 156.9,
                Width = 72.4,
                Thickness = 11.08,
                Weight = 242.5,
                ChargeType = ChargeTypeEnum.TypeC,
                InternalStorage = 512,
                OS = OS.Android,
                RAM = 12,
                Price = 79.999m,
                Stock = 21,
                Status = StatusEnum.Active,
                BrandId = 2
            };

            db.SmartPhones.AddRange(smartPhone_1, smartPhone_2, smartPhone_3, smartPhone_4);
            db.SaveChanges();
        }

        public static async Task SeedUserAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("Customer"))
                await roleManager.CreateAsync(new IdentityRole("Customer"));

            var adminUser = new ApplicationUser()
            {
                Email = "admin@worldphone.com",
                UserName = "admin",
                EmailConfirmed = true,
                Address = "Ankara",
                FirstName = "Admin",
                LastName = "Admin"
            };

            var customerUser = new ApplicationUser()
            {
                Email = "furkanerciyas@worldphone.com",
                UserName = "furkan.erciyas",
                EmailConfirmed = true,
                Address = "Kecioren",
                FirstName = "Furkan",
                LastName = "Erciyas"
            };
            await userManager.CreateAsync(adminUser, "WorldPhone.2024");
            await userManager.AddToRoleAsync(adminUser, "Admin");
            await userManager.CreateAsync(customerUser, "WorldPhone.06");
            await userManager.AddToRoleAsync(customerUser, "Customer");
        }
    }
}
