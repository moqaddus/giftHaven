using Microsoft.AspNetCore.Mvc;
using WebWebWeb.Models;
using System.Text.Json;


namespace WebWebWeb.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View("~/Views/Cart/Cart.cshtml");
        }


        [Route("/Cart/remove/{ItemId}/{a}/{c}")]
        public IActionResult remove(int ItemId,string a ,string c)
        {
            int userid = Convert.ToInt32(Request.Cookies["UserID"]);
            CartRepos rs=new CartRepos();
            rs.RemoveItem(userid, ItemId);
            return RedirectToAction(a,c);
        }



        [Route("/Cart/updateQuantity/{ItemId}/{Quantity}/{a}/{c}")]
        public IActionResult updateQuantity(int ItemId,int Quantity, string a, string c)
        {
            int userid = Convert.ToInt32(Request.Cookies["UserID"]);
            GiftShopOneContext  cx=new GiftShopOneContext();
            var list = cx.Cart.ToList();
            foreach(var item in list)
            {
                if(item.ItemId == ItemId & item.UserId==userid)
                {
                    item.Quantity = Quantity;
                    cx.SaveChanges();
                }
            }
            return RedirectToAction(a, c);
            CartRepos rs=new CartRepos();
            TempData["total"] = rs.getTotal(userid);
        }



        //[HttpPost]
        //public ActionResult AddToCart(int Id)
        //{
        //    var cart = GetOrCreateCart();
        //    ItemRepos itemRepos = new ItemRepos();
        //    // Get the item details based on the itemId (you need to implement this method)
        //    var item = itemRepos.getItem(Id);

        //    if (item != null)
        //    {
        //        // Create a new ShoppingCartItem using the item details
        //        var cartItem = new InventoryItem
        //        {
        //            ItemId = item.ItemId,
        //            ItemName = item.ItemName,
        //            Price = item.Price
        //        };

        //        // Add the item to the cart
        //        cart.AddItem(cartItem);

        //        // Serialize the cart object to a JSON string
        //        var cartJson = JsonSerializer.Serialize(cart);

        //        // Store the updated cart in the session
        //        HttpContext.Session.SetString("Cart", cartJson);

        //        // Return a success response to the client
        //        return Json(new { success = true, message = "Item added to cart" });

        //    }
        //    else
        //    {
        //        // Return an error response to the client if the item is not found
        //        return Json(new { success = false, message = "Item not found" });
        //    }
        //}


        //public Cart GetOrCreateCart()
        //{
        //    var cartJson = HttpContext.Session.GetString("Cart");

        //    if (cartJson != null)
        //    {
        //        // Deserialize the cart JSON string back to a ShoppingCart object
        //        return JsonSerializer.Deserialize<Cart>(cartJson);
        //    }
        //    else
        //    {
        //        return new Cart();
        //    }
        //}



        //    // Implement the logic to retrieve the item details based on the itemId
        //    // Return the item if found, or null if not found

        //    // Placeholder code:


        //public ViewResult NewCart()
        //{

        //    return View();
        //}

    }
}
