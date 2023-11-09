using System;
using System.Collections.Generic;

namespace WebWebWeb;

public partial class OrderItem
{
    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual InventoryItem Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
