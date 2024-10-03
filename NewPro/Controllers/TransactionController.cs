using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPro.Data;
using System.Security.Claims;

namespace NewPro.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ApproveTransaction(int pendingUserId)
        {
            var pendingUser = await _context.Pendingusers.FindAsync(pendingUserId);
            if (pendingUser == null)
            {
                return NotFound("Pending transaction not found.");
            }
            pendingUser.Status = 1; // Set status to Approved
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Error updating status: " + ex.Message);
            }
            return RedirectToAction("Index", "Transaction");
        }
        [Authorize]
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
            //ViewBag.UserId = user.UserId;

            var userDeposits = await _context.Deposits
                                             .Where(d => d.UserId == user.UserId)
                                             .OrderByDescending(d => d.DateAndTime)
                                             .ToListAsync();
            if (userDeposits == null || !userDeposits.Any())
            {
                ViewBag.Message = $"No transactions found";
                return View();
            }
            return View(userDeposits);
        }



        [HttpPost]
        public async Task<IActionResult> ApproveWithdraw(int withdrawId)
        {
            var withdraw = await _context.Withdraws.FindAsync(withdrawId);
            if (withdraw == null)
            {
                return NotFound("Withdrawal not found.");
            }
            withdraw.Status = 1; // Approved
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Error updating withdrawal status: " + ex.Message);
            }
            return RedirectToAction("IndexWithdraw", "Transaction");
        }
        [Authorize]
        public async Task<IActionResult> IndexWithdraw()
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
            //ViewBag.UserId = user.UserId;
            var userWthdraw = await _context.Withdraws
                                             .Where(d => d.UserId == user.UserId)
                                             .OrderByDescending(d => d.DateAndTime)
                                             .ToListAsync();
            if (userWthdraw == null || !userWthdraw.Any())
            {
                ViewBag.Message = $"No transactions found";
                return View();
            }
            return View(userWthdraw);
        }

    }
}
