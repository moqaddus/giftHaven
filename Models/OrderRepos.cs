
using Microsoft.AspNetCore.Mvc;
namespace WebWebWeb.Models
{
    public class OrderRepos
    {
        public int addOrder(Order a,int userid)
        {
            GiftShopOneContext cx=new GiftShopOneContext();
            a.OrderDate= DateTime.Now;
            CartRepos cr=new CartRepos();
            int total = 0;
            total = cr.getTotal(userid);
            a.TotalAmount = Convert.ToString(total);
            cx.Orders.Add(a);
            cx.SaveChanges();
            var list=cx.Orders.ToList();
            foreach(var item in list)
            {
                if(item.CustomerName==a.CustomerName && item.OrderDate==a.OrderDate)
                {
                    return item.OrderId;
                }
            }
            return 0;

        }

        public List<Order> listOrders()
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            List<Order> orders = new List<Order>();
            orders=cx.Orders.ToList();
            return orders;

        }

        public Order findOrder(int id)
        {
            Order order = new Order();
            GiftShopOneContext cx=new GiftShopOneContext();
            order=cx.Orders.Find(id);
            return order;

        }
    }
}
