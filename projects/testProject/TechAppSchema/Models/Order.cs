using System;

namespace TechAppSchema.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreationTime { get; set; }
    public Product Product { get; set; }
    public int LineNumber { get; set; }
    public float Weight { get; set; }
    public string WeightType { get; set; } = "кг.";
    public string Status { get; set; }        
}
