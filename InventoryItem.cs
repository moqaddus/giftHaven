using System;
using System.Collections.Generic;

namespace WebWebWeb;

public partial class InventoryItem:Audit
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? Category { get; set; }

    public int? Price { get; set; }

    public int? Quantity { get; set; }

    public double? Weight { get; set; }

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public string? imagePath { get; set; }


    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}
