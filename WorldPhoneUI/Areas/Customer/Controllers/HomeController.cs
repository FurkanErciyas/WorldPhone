using BLL.Interfaces;
using ENTITIES.DTOS.PhoneDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldPhoneUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private readonly IPhoneService _phone;

        public HomeController(IPhoneService phone)
        {
            _phone = phone;
        }
        public IActionResult Index()
        {
            var phonesDTO = _phone.GetPhonesDTO();
            return View(phonesDTO);
        }
        public IActionResult GetPhonesByBrand(string brandName)
        {

            return View("Index", _phone.GetPhonesByBrand(brandName));
        }
    }
}
