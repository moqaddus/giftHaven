using Microsoft.AspNetCore.Mvc;
using WebWebWeb.Models;

namespace WebWebWeb.Controllers
{
    public class GiftBasketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Basket(int id)
        {
            if (id != null)
            {
                int userid = Convert.ToInt32(Request.Cookies["UserID"]);
                CartRepos r = new CartRepos();
                r.AddItem(userid, id);
                /*
                r.AddItem(Convert.ToInt32(TempData["userid"]),id);


                string s = Convert.ToString(id + " ");
                if (!(HttpContext.Session.Keys.Contains("cart")))
                {
                    HttpContext.Session.SetString("cart",s);
                }
                else
                {
                    string? data = HttpContext.Session.GetString("cart");
                    HttpContext.Session.SetString("cart", data+s);


                }
                */

            }


            ItemRepos rs = new ItemRepos();
            List<InventoryItem> items = new List<InventoryItem>();
            items = rs.findGiftBasketItems();
            return View(items);
        }
    }
}
