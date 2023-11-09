using Microsoft.AspNetCore.Mvc;
using WebWebWeb.Models;

namespace WebWebWeb.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult placement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult placement(Order od)
        {
            OrderRepos rs=new OrderRepos();
            int userid = Convert.ToInt32(Request.Cookies["UserID"]);
            int id=rs.addOrder(od,userid);//

            OrderItemsRepos rs2=new OrderItemsRepos();
            rs2.addOrderItems(userid,id);
            CartRepos rs3=new CartRepos();
            rs3.RemoveUser(userid);
            //string data= HttpContext.Session.GetString("cart");
            //OrderItemsRepos rp=new OrderItemsRepos();//
            //rp.addItems(data, id);///
            return RedirectToAction("Confirmed", "Order", new {id=od.OrderId});
        }


        public IActionResult Confirmed(int id)
        {
            OrderRepos rs = new OrderRepos();

            return View(rs.findOrder(id));
        }
    }
}
