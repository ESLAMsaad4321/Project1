using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public partial class LevelOfLanguage
{
    [Key]
    public int Id { get; set; }

    public string Language { get; set; } = null!;

    public string Languagelevel { get; set; } = null!;
}
