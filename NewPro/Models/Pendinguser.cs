using System;
using System.Collections.Generic;

namespace NewPro.Models;

public partial class Pendinguser
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string Acc { get; set; } = null!;

    public int AccType { get; set; }

    public int Amount { get; set; }

    public string BankName { get; set; } = null!;

    public DateTime DateAndTime { get; set; }

    public string DocId { get; set; } = null!;

    public string Proof { get; set; } = null!;

    public int Status { get; set; }

    public string To { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Whatsapp { get; set; } = null!;

    public string SenderAccNum { get; set; } = null!;

    public string SenderAccName { get; set; } = null!;

    public string SenderAccTrxId { get; set; } = null!;

    public string BetProUsername { get; set; } = null!;
}
