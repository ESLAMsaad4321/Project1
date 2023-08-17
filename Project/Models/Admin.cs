using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public partial class Admin
{
    public string Email { get; set; } = null!;
    [Key]
    public int UserId { get; set; }
    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }
}
