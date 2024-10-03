using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewPro.Models;

public partial class User
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = GenerateUserId();

    public int UserAmount { get; set; } = 0; // Default to 0

    public string UserBetproPassword { get; set; } = string.Empty;

    public string UserBetproUsername { get; set; } = string.Empty;

    public int UserBlocked { get; set; } = 0; // Default to 0

    [Required]
    public string UserEmail { get; set; } = string.Empty;

    [Required]
    public string UserFullname { get; set; } = string.Empty;

    public string UserNumber { get; set; } = string.Empty;

    [Required]
    public string UserPassword { get; set; } = string.Empty;

    public string UserRealPass { get; set; } = string.Empty;

    [Required]
    public string UserType { get; set; } = "1"; // Default to email (1)

    public string UserWhatsapp { get; set; } = string.Empty;

    public int UserActive { get; set; } = 0; // Default to 0

    public string MsgToken { get; set; } = string.Empty;

    // Method to generate a unique UserId
    private static string GenerateUserId()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var userId = "User_" + new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return userId;
    }
}
