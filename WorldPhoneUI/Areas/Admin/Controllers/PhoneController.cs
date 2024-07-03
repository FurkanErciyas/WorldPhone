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
            string extension = Path.GetExtension(phone.Image.FileName);
            string fileName = Guid.NewGuid() + extension;
            string savePath = Path.Combine(_env.WebRootPath, "img", fileName);

            using (var stream = System.IO.File.Create(savePath))
            {
                phone.Image.CopyTo(stream);
            }

            _phone.AddPhone(phone, fileName);

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        public IActionResult EditPhone(int id)
        {
            var phoneDTO = _phone.EditPhoneDTO(id);
            var brands = _brand.GetAllBrands();
            phoneDTO.Brands = brands;
            return View(phoneDTO);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditPhone(EditPhoneDTO phoneDTO)
        {

            if (!ModelState.IsValid)
            {
                if (phoneDTO.Image != null && phoneDTO.Image.Length > 0)
                {
                    string extension = Path.GetExtension(phoneDTO.Image.FileName);
                    string fileName = Guid.NewGuid() + extension;
                    string savePath = Path.Combine(_env.WebRootPath, "img", fileName);

                    using (var stream = System.IO.File.Create(savePath))
                    {
                        phoneDTO.Image.CopyTo(stream);
                    }
                }
                else
                {
                    var phone = _phone.GetPhone(phoneDTO.Id);
                    phoneDTO.PicturePath = phone.PicturePath;
                }
            }

            _phone.EditPhone(phoneDTO);
            return RedirectToAction("ListPhone", "Phone", new { area = "Admin" });
        }

        public IActionResult ListPhone()
        {
            return View(_phone.GetAllPhones());
        }

        public IActionResult DeletePhone(int id)
        {
            _phone.DeletePhone(id);
            return View();
        }


    }
}
