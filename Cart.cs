namespace WebWebWeb
{
    public class Cart
    {
        public int UserId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public virtual InventoryItem Item { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
