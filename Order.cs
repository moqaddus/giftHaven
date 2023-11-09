using System;
using System.Collections.Generic;

namespace WebWebWeb;
public partial class Order
{
    public int OrderId { get; set; }

    public string? CustomerName { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? TotalAmount { get; set; }

    public string? City { get; set; }

    public string? Zip { get; set; }

    public string? Email { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Cnn { get; set; }

    public string? Cvv { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



}
