using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Formulation> Formulations { get; set; } = new List<Formulation>();

    public virtual ICollection<TechCard> TechCards { get; set; } = new List<TechCard>();
}
