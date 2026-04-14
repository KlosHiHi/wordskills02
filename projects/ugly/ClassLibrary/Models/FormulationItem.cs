using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class FormulationItem
{
    public int FormulationId { get; set; }

    public int ItemId { get; set; }

    public sbyte? Quantity { get; set; }

    public virtual Formulation Formulation { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
