using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class TechCardStep
{
    public int Id { get; set; }

    public int TechCardId { get; set; }

    public string? Name { get; set; }

    public sbyte? IsRequired { get; set; }

    public int? Number { get; set; }

    public virtual TechCard TechCard { get; set; } = null!;
}
