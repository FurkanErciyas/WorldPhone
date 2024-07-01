using BLL.Interfaces;
using ENTITIES.DTOS.PhoneDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldPhoneUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhoneController : Controller
    {
        private readonly IPhone _phone;
        private readonly IBrand _brand;
        private readonly IWebHostEnvironment _env;

        public PhoneController(IPhone phone, IBrand brand, IWebHostEnvironment env)
        {
            _phone = phone;
            _brand = brand;
            _env = env;
        }

        public IActionResult AddPhone()
        {
            var brands = _brand.GetAllBrands();
            var model = new AddPhoneDTO
            {
                Brands = brands
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddPhone(AddPhoneDTO phone)
        {
            _phone.AddPhone(phone);

            //string extension = Path.GetExtension(phone.Image.FileName);
            //string fileName = Guid.NewGuid() + extension;
            string savePath = Path.Combine(_env.WebRootPath, "img", phone.Image.FileName);

            using (var stream = System.IO.File.Create(savePath))
            {
                phone.Image.CopyTo(stream);
            }

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        public IActionResult ListPhone()
        {
            return View(_phone.GetAllPhones());
        }
    }
}
