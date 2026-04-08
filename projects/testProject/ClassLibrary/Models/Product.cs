using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public bool? Status { get; set; }
}
