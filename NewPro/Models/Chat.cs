using System;
using System.Collections.Generic;

namespace NewPro.Models;

public partial class Chat
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime Date { get; set; }

    public string ImagePathLocal { get; set; } = null!;

    public int SentType { get; set; }

    public int MsgType { get; set; }

    public string Image { get; set; } = null!;
}
