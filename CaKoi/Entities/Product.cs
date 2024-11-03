using System;
using System.Collections.Generic;

namespace CaKoi.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Category { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
