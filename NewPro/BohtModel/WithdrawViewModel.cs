using NewPro.Models;
using System.ComponentModel.DataAnnotations;

namespace NewPro.BohtModel
{
    public class WithdrawViewModel
    {
        [Required]
        public Account Account { get; set; }

        [Required]
        [Range(1000, int.MaxValue, ErrorMessage = "Amount must be greater than 1000.")]
        public int Amount { get; set; }
        public string UserNumber { get; set; }
        public string UserAccountType { get; set; }
        public string UserBankName { get; set; }
        public string UserFullname { get; set; }
    }
}
