using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public partial class Login
{
    public string Emil { get; set; } = null!;

    public string Password { get; set; } = null!;
    [Key]
    public int UserId { get; set; }

    public string Security { get; set; } = null!;
}
