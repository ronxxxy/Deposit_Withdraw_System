using NewPro.Models;

namespace NewPro.BohtModel
{
    public class DepositPaywallViewModel
    {
        public Account Account { get; set; } // Make sure this is present
        public IFormFile Receipt { get; set; }
        public string Proof { get; set; }
        public decimal Amount { get; set; }
    }
}
