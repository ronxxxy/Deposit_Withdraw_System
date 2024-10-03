using System;
using System.Collections.Generic;

namespace NewPro.Models;

public partial class Status
{
    public int Id { get; set; }

    public int MinDeposit { get; set; }

    public int MaxDeposit { get; set; }

    public int MinWithdraw { get; set; }

    public int MaxWithdraw { get; set; }

    public string AdsInitUId { get; set; } = null!;

    public int AdsOnOff { get; set; }

    public string AdsRewardedUId { get; set; } = null!;

    public string GUserId { get; set; } = null!;

    public int MaintenanceDialog { get; set; }

    public string MessagingKey { get; set; } = null!;

    public string MessagingKey1 { get; set; } = null!;

    public string PackageName { get; set; } = null!;

    public string StatusMsg { get; set; } = null!;

    public int StatusOn { get; set; }

    public string Url { get; set; } = null!;

    public string Url1 { get; set; } = null!;

    public string Url2 { get; set; } = null!;

    public int VersionCode { get; set; }

    public int WebPageUrlNum { get; set; }

    public string YoutubeLink { get; set; } = null!;
}
