using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WorldPhone.DAL.Context;
using WorldPhone.ENTITIES.Models;
using WorldPhoneUI.Models;

namespace WorldPhoneUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WorldPhoneDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, WorldPhoneDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _db.Users.Find(userId);
            var userIsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            var userIsCustomer = await _userManager.IsInRoleAsync(user, "Customer");

            if(user != null)
            {
                if (userIsAdmin)
                    TempData["Greetings"] = $"{user.FirstName} {user.LastName} Welcome to World Phone Admin Panel";
                else
                    TempData["Greetings"] = $"{user.FirstName} {user.LastName} Welcome to World Phone Customer Panel";

                if (_signInManager.IsSignedIn(User))
                {
                    if (userIsCustomer)
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                    if (userIsAdmin)
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
