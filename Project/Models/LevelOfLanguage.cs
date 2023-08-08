using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class LevelOfLanguage
{
    public int Id { get; set; }

    public string Language { get; set; } = null!;

    public string Languagelevel { get; set; } = null!;
}
