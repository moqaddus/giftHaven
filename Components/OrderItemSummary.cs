using WebWebWeb.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebWebWeb.Components
{
    public class OrderItemSummary:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int getTotal = 0;
            List<int> ls = new List<int>();
            List<InventoryItem> items = new List<InventoryItem>();
            GiftShopOneContext cx = new GiftShopOneContext();
            var cartItems = cx.Cart.ToList();
            int userid = Convert.ToInt32(Request.Cookies["UserID"]);
            ItemRepos itemrepos = new ItemRepos();
            InventoryItem temp = new InventoryItem();
            int? total = 0;
            foreach (var item in cartItems)
            {
                if (item.UserId == userid)
                {
                    temp = itemrepos.getItem(item.ItemId);
                    total += temp.Price * item.Quantity;
                    temp.Quantity = item.Quantity;

                    items.Add(temp);
                }
            }
            TempData["total"] = total;



            return View(items);
        }
    }
}
