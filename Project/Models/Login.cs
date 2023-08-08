using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Login
{
    public string Emil { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Security { get; set; } = null!;
}
