using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public partial class Account
{
    public string Name { get; set; } = null!;
    [Key]
    public int Id { get; set; }

    public string? Nationalid { get; set; }

    public DateTime Dateofbirth { get; set; }

    public string Language { get; set; } = null!;

    public string Languagelevel { get; set; } = null!;

    public string Account1 { get; set; } = null!;

    public string? Lineofbusiness { get; set; }
}
