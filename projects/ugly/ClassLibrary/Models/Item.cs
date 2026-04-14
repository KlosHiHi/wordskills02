using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<FormulationItem> FormulationItems { get; set; } = new List<FormulationItem>();
}
