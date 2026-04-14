using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class Formulation
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public sbyte? IsCurrent { get; set; }

    public virtual ICollection<FormulationItem> FormulationItems { get; set; } = new List<FormulationItem>();

    public virtual Product Product { get; set; } = null!;
}
