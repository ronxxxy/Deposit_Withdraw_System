using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPro.BohtModel;
using NewPro.Data;
using NewPro.Models;
using System.Security.Claims;

namespace NewPro.Controllers
{
    public class WithdrawController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WithdrawController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Withdraw Page
        [Authorize]
        public async Task<IActionResult> Withdraw()
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
            var pendingwithdraw = await _context.Withdraws
                                               .FirstOrDefaultAsync(d => d.UserId == user.UserId && d.Status == 0);
            if (pendingwithdraw != null)
            {
                TempData["WithdrawError"] = "You cannot make a new withdraw until your previous withdraw has been approved.";
                return RedirectToAction("IndexWithdraw", "Transaction");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(WithdrawViewModel model)
        {
            if (ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return View(model);
            }
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "User");
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Convert.ToInt32(userId));

            var withdraw = new Withdraw
            {
                UserId = user.UserId,
                Acc = null,
                AccType = null,
                Amount = model.Amount,
                BankName = null,
                DateAndTime = DateTime.Now,
                DocId = GenerateDocId(),
                Proof = null, 
                Status = 0,
                To = null,
                Username = user.UserFullname,
                Whatsapp = user.UserWhatsapp,
                SenderAccNum = model.UserNumber,
                SenderAccName = model.UserFullname,
                SenderAccType = model.UserAccountType,
                SenderBankName = model.UserAccountType == "Bank" ? model.UserBankName : "Not Applicable",
                SenderAccTrxId = GenerateTrxId(),
                BetProUsername = user.UserBetproUsername
            };
            var status = new Status
            {
                MinDeposit = 1000,
                MaxDeposit = 100000,
                MinWithdraw = 1000,
                MaxWithdraw = 100000,
                GUserId = user.UserId,
                StatusOn = withdraw.Status, // 0 for pending
                VersionCode = GenerateVersionCode(), // Generating version code
                AdsInitUId = null,
                AdsRewardedUId = null,
                MessagingKey = null,
                MessagingKey1 = null,
                PackageName = null,
                StatusMsg = "Withdraw Purpose",
                Url = null,
                Url1 = null,
                Url2 = null,
                YoutubeLink = null,
                MaintenanceDialog = 0, // Assuming default value
                WebPageUrlNum = 0 // Assuming default value
            };
            try
            {
                _context.Withdraws.Add(withdraw);
                _context.Statuses.Add(status);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest("Error saving data: " + innerException);
            }
            return RedirectToAction("IndexWithdraw", "Transaction");
        }


        private int GenerateVersionCode()
        {
            var lastVersionCode = _context.Statuses.OrderByDescending(s => s.VersionCode).FirstOrDefault()?.VersionCode ?? 0;
            return lastVersionCode + 1;
        }
        private string GenerateDocId()
        {
            return Guid.NewGuid().ToString();
        }
        private string GenerateTrxId()
        {
            return "TRX_" + Guid.NewGuid().ToString();
        }
    }
}
