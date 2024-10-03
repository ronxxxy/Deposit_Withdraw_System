using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPro.BohtModel;
using NewPro.Data;
using NewPro.Models;
using SkiaSharp;
using System.Security.Claims;

namespace NewPro.Controllers
{
    public class DepositController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepositController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Deposit Page
        [Authorize]
        public async Task<IActionResult> Deposit()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "User"); // Redirect if not authenticated
            }
            var userId = int.Parse(userIdClaim.Value);
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var pendingDeposit = await _context.Deposits
                                               .FirstOrDefaultAsync(d => d.UserId == user.UserId && d.Status == 0);

            if (pendingDeposit != null)
            {
                TempData["DepositError"] = "You cannot make a new deposit until your previous deposit has been approved.";
                return RedirectToAction("Index", "Transaction");
            }
            ViewBag.ShowFooter = false;
            return View();
        }





        //Deposit Wall Page
        [Authorize]
        public IActionResult DepositPaywall(string accountId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "User"); // Redirect if not authenticated
            }

            var amount = HttpContext.Session.GetString("DepositAmount");
            if (amount != null)
            {
                ViewBag.DepositAmount = decimal.Parse(amount);
            }

            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                return NotFound("Account not found.");
            }
            HttpContext.Session.SetString("AccountId", account.AccountId);
            HttpContext.Session.SetString("AccountTitle", account.AccountTitle);

            var viewModel = new DepositPaywallViewModel
            {
                Account = account 
            };

            ViewBag.ShowFooter = false;
            ViewBag.AccountId = accountId;

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> DepositPaywall(DepositPaywallViewModel model)
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
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == model.Account.AccountId && a.AccountActive == 1);

            if (user == null || account == null)
            {
                return NotFound("User or account not found.");
            }

            if (model.Receipt != null)
            {
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }
                var fileName = Guid.NewGuid() + Path.GetExtension(model.Receipt.FileName);
                var filePath = Path.Combine(uploadsDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Receipt.CopyToAsync(stream);
                }
                model.Proof = fileName;
            }

            var depositAmount = HttpContext.Session.GetString("DepositAmount");
            var deposit = new Deposit
            {
                UserId = user.UserId,
                Acc = account.AccountNumber,
                AccType = account.AccountType,
                Amount = Convert.ToInt32(depositAmount),
                BankName = account.AccountBankName,
                DateAndTime = DateTime.Now,
                DocId = GenerateDocId(),
                Proof = model.Proof,
                Status = 0, // Pending status
                To = account.AccountTitle,
                Username = user.UserFullname,
                Whatsapp = user.UserWhatsapp,
                SenderAccNum = user.UserNumber,
                SenderAccName = user.UserFullname,
                SenderAccTrxId = GenerateTrxId(),
                BetProUsername = user.UserBetproUsername
            };

            var pendingUser = new Pendinguser
            {
                UserId = user.UserId,
                Acc = account.AccountNumber,
                AccType = account.AccountType,
                Amount = deposit.Amount,
                BankName = account.AccountBankName,
                DateAndTime = DateTime.Now,
                DocId = deposit.DocId,
                Proof = deposit.Proof,
                Status = 0, // Pending status
                To = deposit.To,
                Username = deposit.Username,
                Whatsapp = deposit.Whatsapp,
                SenderAccNum = deposit.SenderAccNum,
                SenderAccName = deposit.SenderAccName,
                SenderAccTrxId = deposit.SenderAccTrxId,
                BetProUsername = deposit.BetProUsername
            };

            var status = new Status
            {
                MinDeposit = 1000,
                MaxDeposit = 100000,
                MinWithdraw = 1000,
                MaxWithdraw = 100000,
                GUserId = user.UserId,
                StatusOn = deposit.Status, // 0 for pending
                VersionCode = GenerateVersionCode(), // Generating version code
                AdsInitUId = null,
                AdsRewardedUId = null,
                MessagingKey = null,
                MessagingKey1 = null,
                PackageName = null,
                StatusMsg = "Deposit Purpose",
                Url = null,
                Url1 = null,
                Url2 = null,
                YoutubeLink = null,
                MaintenanceDialog = 0, // Assuming default value
                WebPageUrlNum = 0 // Assuming default value
            };
            try
            {

                _context.Deposits.Add(deposit);
                _context.Pendingusers.Add(pendingUser);
                _context.Statuses.Add(status);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Error saving data: " + ex.Message);
            }

            return RedirectToAction("Index", "Transaction");
        }


        private int GenerateVersionCode()
        {
            var lastVersionCode = _context.Statuses.OrderByDescending(s => s.VersionCode).FirstOrDefault()?.VersionCode ?? 0;
            return lastVersionCode + 1;
        }
        private string GenerateDocId()
        {
            return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
        private string GenerateTrxId()
        {
            return "TRX-" + new Random().Next(100000, 999999).ToString();
        }
        public IActionResult DownloadReceipt()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "User");
            }
            var amountString = HttpContext.Session.GetString("DepositAmount");
            if (string.IsNullOrEmpty(amountString) || !decimal.TryParse(amountString, out var amount))
            {
                return NotFound("Amount is not available or invalid.");
            }
            var accountId = HttpContext.Session.GetString("AccountId");
            if (string.IsNullOrEmpty(accountId))
            {
                return NotFound("Account ID is not available.");
            }
            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                return NotFound("Account is not found.");
            }
            byte[] receiptImage = GenerateReceiptImage(account, amount);
            return File(receiptImage, "image/png", "DepositReceipt.png");
        }

        // Method to generate a receipt image (JPG or PNG)
        private byte[] GenerateReceiptImage(Account account, decimal amount)
        {
            int width = 600;  // Image width
            int height = 400; // Image height

            using (var surface = SKSurface.Create(new SKImageInfo(width, height)))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);  // Set background color

                var textPaint = new SKPaint
                {
                    Color = SKColors.Black,
                    IsAntialias = true,
                    TextSize = 24
                };
                canvas.DrawText("Deposit Receipt", 20, 40, textPaint);
                canvas.DrawText($"Generated on: {DateTime.Now}", 20, 80, textPaint);
                canvas.DrawText($"Account ID: {account.AccountId}", 20, 120, textPaint);
                canvas.DrawText($"Account Number: {account.AccountNumber}", 20, 160, textPaint);
                canvas.DrawText($"Account Title: {account.AccountTitle}", 20, 200, textPaint);
                canvas.DrawText($"Bank Name: {account.AccountBankName}", 20, 240, textPaint);
                canvas.DrawText($"Deposit Amount: {amount:F2}", 20, 280, textPaint);

                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100)) // Encode to PNG
                {
                    return data.ToArray();
                }
            }
        }



    }
}
