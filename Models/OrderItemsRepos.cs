namespace WebWebWeb.Models
{
    public class OrderItemsRepos
    {
        public List<OrderItem> getAll()
        {
            GiftShopOneContext cx=new GiftShopOneContext();
            var itemsList=cx.OrderItems.ToList();
            return itemsList;

        }


        public void addOrderItems(int userId,int orderId)
        {
            CartRepos rs=new CartRepos();
            var list = rs.getAll();

            GiftShopOneContext cx = new GiftShopOneContext();
            OrderItem itemItem = new OrderItem();
            foreach ( var item in list)
            {
                if (item.UserId == userId)
                {
                    itemItem.OrderId = orderId;
                    itemItem.ItemId = item.ItemId;
                    itemItem.Quantity=item.Quantity;
                    cx.OrderItems.Add(itemItem);
                    cx.SaveChanges();
                }
            }

            InventoryItem Item=new InventoryItem();
            foreach(var item in list)
            {
                if(item.UserId == userId)
                {
                    Item = cx.InventoryItems.Find(item.ItemId);
                    Item.Quantity -= item.Quantity;
                    cx.SaveChanges();

                }
            }
            

        }


        //public void addItems(string str,int orderId)/// ///// //// 
        //{
        //    GiftShopOneContext cx = new GiftShopOneContext();
        //    var data = str.Split(' ');
        //    OrderItem item = new OrderItem();
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        item.OrderId = orderId;
        //        if (int.TryParse(data[i], out int itemId))
        //        {
        //            item.ItemId = itemId;
        //            item.Quantity = 1;
        //            cx.OrderItems.Add(item);
        //        }
        //        else
        //        {
                    
        //        }
        //    }
        //}
    }
}
