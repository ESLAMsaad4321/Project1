using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public partial class LineOfAccount
{
    [Key]
    public int Id { get; set; }

    public string Account { get; set; } = null!;

    public string Lineofbusiness { get; set; } = null!;
}
