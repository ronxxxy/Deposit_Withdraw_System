using Microsoft.AspNetCore.Mvc;
using NewPro.Data;

namespace NewPro.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ActivateUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.UserActive = 1; // Activate the user
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            return RedirectToAction("Index", "Home"); // Redirect to a user list or similar
        }
    }
}
