using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class TechCard
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<TechCardStep> TechCardSteps { get; set; } = new List<TechCardStep>();
}
