using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPro.Data;
using NewPro.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace NewPro.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ShowNavbar = false;
            ViewBag.ShowFooter = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                int userType;
                if (IsEmail(model.UserEmail))
                {
                    userType = 1;
                }
                else if (IsPhoneNumber(model.UserNumber))
                {
                    userType = 2;
                }
                else
                {
                    ModelState.AddModelError("UserType", "Please provide a valid email or phone number.");
                    return View(model);
                }

                var user = new User
                {
                    UserFullname = model.UserFullname,
                    UserEmail = model.UserEmail,
                    UserWhatsapp = model.UserWhatsapp,
                    UserPassword = HashPassword(model.UserPassword), // Store hashed password
                    UserBetproPassword = GenerateBetproPassword(model.UserPassword),
                    UserBetproUsername = GenerateBetproUsername(model.UserFullname),
                    UserNumber = model.UserNumber,
                    UserRealPass = string.Empty,
                    MsgToken = string.Empty,
                    UserBlocked = 0,
                    UserActive = 0,
                    UserType = userType.ToString()
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserFullname),
                    new Claim(ClaimTypes.Email, user.UserEmail)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "YourCookieAuthScheme");

                await HttpContext.SignInAsync("YourCookieAuthScheme", new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            ViewBag.ShowNavbar = false;
            ViewBag.ShowFooter = false;
            return View(model);
        }

        // User Login
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ShowNavbar = false;
            ViewBag.ShowFooter = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail && u.UserPassword == model.UserPassword);

            if (user != null)
            {
                if (user.UserBlocked == 1)
                {
                    ViewBag.ErrorMessage = "Your account is blocked. Please contact support.";
                    return View();
                }

                // Set user ID in session
                HttpContext.Session.SetString("UserId", user.Id.ToString());

                // Set persistent cookie for login
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.UserEmail)
        };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync("YourCookieAuthScheme", claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = true, // This makes the cookie persistent
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30) // Cookie expires in 30 days
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                ViewBag.ShowNavbar = false;
                ViewBag.ShowFooter = false;
                return View(model);
            }
        }

        //Login Close
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.SignOutAsync("YourCookieAuthScheme"); // Sign out of the authentication scheme
            return RedirectToAction("Login", "User");
        }
        //LOGOUT CLOSE
        public IActionResult Accounts()
        {
            ViewBag.ShowNavbar = false;
            ViewBag.ShowFooter = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accounts(Account account, IFormFile imageFile)
        {
            account.AccountId = GenerateShortAccountId(8);
            account.AccountActive = 1;

            if (!ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lib/Assets/images");
                    var filePath = Path.Combine(uploads, imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    account.ImagePath = $"{imageFile.FileName}";
                }
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "User");
            }
            return View(account);
        }




        // Utility methods
        private bool IsEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && new EmailAddressAttribute().IsValid(email);
        }
        private bool IsPhoneNumber(string number)
        {
            return !string.IsNullOrEmpty(number) && number.All(char.IsDigit);
        }
        private string GenerateBetproUsername(string fullname)
        {
            var firstLetter = char.ToUpper(fullname[3]);
            var random = new Random();
            var randomDigits = random.Next(100, 1000);
            var username = $"{firstLetter}{randomDigits}";
            return username;
        }
        private string GenerateBetproPassword(string userPassword)
        {
            var random = new Random();
            var randomDigits = random.Next(100, 1000).ToString();
            string betproPassword = userPassword.Replace("@", randomDigits);
            if (!userPassword.Contains("@") || userPassword.Count(c => c == '@') < 3)
            {
                betproPassword += randomDigits;
            }
            return betproPassword;
        }
        private string HashPassword(string password)
        {
            return password;
        }

        private string GenerateShortAccountId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
