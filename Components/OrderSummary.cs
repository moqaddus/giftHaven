using WebWebWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebWebWeb.Component
{
    public class OrderSummary:ViewComponent
    {

       
        public IViewComponentResult Invoke()
        {
            List<tempOrderItem> itemNames = new List<tempOrderItem>();
            OrderItemsRepos rs = new OrderItemsRepos();
            List<OrderItem> orders = new List<OrderItem>();

            orders = rs.getAll();
            foreach (var items in orders)
            {

                ItemRepos itemrepos = new ItemRepos();
                InventoryItem i = itemrepos.getItem(items.ItemId);
                tempOrderItem t=new tempOrderItem();
                if (i != null)
                {
                    t.OrderId = items.OrderId;
                    t.Name = i.ItemName;
                    itemNames.Add(t);
                }
                
            }
            return View(itemNames);
        }

    }
}
