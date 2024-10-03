using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPro.Data;
using NewPro.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace NewPro.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        //Home Page
        [Authorize(AuthenticationSchemes = "YourCookieAuthScheme")]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "User"); // Redirect if not authenticated
            }
            var userId = int.Parse(userIdClaim.Value);
            //Fetch From Datbase
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            if (user.UserActive == 0)
            {
                ViewBag.ErrorMessage = "Your account is currently inactive. Please reach out to the support team for further assistance.";
            }
            return View(user);
        }



        //Account List Page
        [Authorize]
        public async Task<IActionResult> AccountList(decimal amount)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "User"); // Redirect if not authenticated
            }

            HttpContext.Session.SetString("DepositAmount", amount.ToString());

            var accounts = await _context.Accounts.ToListAsync();
            ViewBag.ShowFooter = false;
            return View(accounts);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
