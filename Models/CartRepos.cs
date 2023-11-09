using Microsoft.AspNetCore.Mvc;


namespace WebWebWeb.Models
{
    public class CartRepos
    {

        public void RemoveItem(int userId,int itemId)
        {
            GiftShopOneContext cx=new GiftShopOneContext();
            var Cart=cx.Cart.ToList();
            foreach (var item in Cart)
            {
                if (item.ItemId == itemId && item.UserId == userId)
                {
                    cx.Cart.Remove(item);
                    cx.SaveChanges();
                }
            }
        }

        public void RemoveUser(int userId)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            var Cart = cx.Cart.ToList();
            foreach (var item in Cart)
            {
                if (item.UserId == userId)
                {
                    cx.Cart.Remove(item);
                    cx.SaveChanges();
                }
            }
        }

        public void AddItem(int userId, int itemId)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            var cartItems = cx.Cart.ToList();
            int check = 0;
            foreach(var item in cartItems)
            {
                if(item.UserId == userId && item.ItemId==itemId)
                {
                    check = 1;
                    var theItem = cx.InventoryItems.Find(item.ItemId);
                    if(theItem.Quantity > item.Quantity)
                    {
                        item.Quantity += 1;
                        cx.SaveChanges();

                    }
                   
                    break;
                }
            }
            if (check == 0)
            {
                if (cx.Users.Find(userId) != null && cx.InventoryItems.Find(itemId) != null)
                {
                    Cart cart = new Cart();
                    cart.UserId = userId;
                    cart.ItemId = itemId;
                    cart.Quantity = 1;
                    cx.Cart.Add(cart);
                    cx.SaveChanges();
                }
            }
        }

        public List<Cart> getAll()
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            return cx.Cart.ToList();

        }

        public int getTotal(int userid)
        {
            int getTotal = 0;
            List<int> ls= new List<int>();
            GiftShopOneContext cx = new GiftShopOneContext();
            var cartItems= cx.Cart.ToList();

            ItemRepos itemrepos = new ItemRepos();
            InventoryItem temp=new InventoryItem();

            foreach(var item in cartItems)
            {
                if(item.UserId == userid)
                {
                    temp=itemrepos.getItem(item.ItemId);
                    if (temp is not null)
                    {
                        int t = (int)temp.Price;
                        if (temp.Price is not null)
                        {
                            getTotal += t * item.Quantity;
                        }
                    }
                }
            }
            return getTotal;

        }





    }
}
