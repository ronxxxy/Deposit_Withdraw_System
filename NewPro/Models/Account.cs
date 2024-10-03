using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewPro.Models;

public partial class Account
{
    internal string? UserId;

    [Key]
    public int Id { get; set; }

    public string AccountId { get; set; } = null!;

    [Required(ErrorMessage = "Please select a payment method.")]
    public int AccountActive { get; set; } = 1; 

    [Required(ErrorMessage = "Bank Name is required.")]
    public string AccountBankName { get; set; } = null!;

    [Required(ErrorMessage = "Account Number is required.")]
    public string AccountNumber { get; set; } = null!;

    [Required(ErrorMessage = "Account Title is required.")]
    public string AccountTitle { get; set; } = null!;

    [Required(ErrorMessage = "Please select an account type.")]
    public int AccountType { get; set; }
    public string ImagePath { get; set; } = null!;

    // Method to convert AccountType to string
    private string GetAccountTypeString(int AccountType)
    {
        return AccountType switch
        {
            1 => "Easy Paisa",
            2 => "Jazz Cash",
            3 => "Bank",
            0 => "Unknown"
        };
    }
}
