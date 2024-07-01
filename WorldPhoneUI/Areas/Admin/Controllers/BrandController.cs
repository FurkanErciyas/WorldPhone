using BLL.Interfaces;
using ENTITIES.DTOS.BrandDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldPhoneUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IBrand _brand;

        public BrandController(IBrand brand)
        {
            _brand = brand;
        }
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBrand(AddBrandDTO brandDTO)
        {
            _brand.AddBrand(brandDTO);
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
    }
}
