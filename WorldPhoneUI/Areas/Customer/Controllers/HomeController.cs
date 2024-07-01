using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorldPhoneUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private readonly ICustomer _customer;

        public HomeController(ICustomer customer)
        {
            _customer = customer;
        }
        public IActionResult Index()
        {
            return View(_customer.GetBrands());
        }
    }
}
