using Microsoft.AspNetCore.Mvc;
using WebWebWeb.Models;

namespace WebWebWeb.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Signin(string? userName)
        {
            object s = userName;
            return View(s);
        }

        [HttpPost]
        public ViewResult Signin(InventoryItem item)
        {
            ItemRepos rs=new ItemRepos();
            item.ModifiedBy = Request.Cookies["adminName"];
            item.ModifiedDateTime=DateTime.Now;
            rs.removeProduct(item);
            object s = "Item removed successfully";
            return View(s);
        }

        [HttpPost]
        public IActionResult Signin2(InventoryItem item)
        {
            ItemRepos rs = new ItemRepos();
            bool check=rs.isItem(item);
            if(check)
            {
                return RedirectToAction("updateProduct", "Admin");
            }
            return View("~/ Views / Admin / Signin.cshtml");
        }

        [HttpGet]
        public ViewResult updateProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult updateProduct(InventoryItem item)
        {
            ItemRepos rs = new ItemRepos();
            rs.updateProduct(item);
            item.ModifiedBy = Request.Cookies["adminName"];
            item.ModifiedDateTime = DateTime.Now;
            return RedirectToAction("Signin", "Admin");

        }



        [HttpGet]
        public ViewResult addProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addProduct(InventoryItem item)
        {
            ItemRepos rs=new ItemRepos();
            item.CreatedBy = Request.Cookies["adminName"];
            item.CreatedDateTime = DateTime.Now;
            rs.addProduct(item);

            return RedirectToAction("Signin", "Admin", new { userName = "Item Added Successfully!" } );
        }


        [HttpGet]
        public ViewResult addAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addAdmin(Admin a)
        {
            AdminRepost rs=new AdminRepost();
            rs.addAdmin(a);
            return RedirectToAction("Signin", "Admin", new { userName = "Admin Added Successfully!" });
        }


        public ViewResult viewOrders()
        {
            //if (!HttpContext.Request.Cookies.ContainsKey("LastVisit"))
            //{
            //    var lastVisitTime = DateTime.Now.ToString();
            //    HttpContext.Response.Cookies.Append("LastVisit", lastVisitTime);
            //    TempData["time"] = "You visited for the first time";
            //}
            //else
            //{
            //    var lastVisitTime = Request.Cookies["LastVisit"];
            //    HttpContext.Response.Cookies.Delete("LastVisit");
            //    TempData["time"] = "You visited on " + lastVisitTime;
            //    lastVisitTime = DateTime.Now.ToString();
            //    HttpContext.Response.Cookies.Append("LastVisit", lastVisitTime);
            //}


            if (!(HttpContext.Session.Keys.Contains("LastVisit")))
            {
                HttpContext.Session.SetString("LastVisit", DateTime.Now.ToString());
                TempData["visit"] = "This is your first visit";
            }
            else
            {
                string? data = HttpContext.Session.GetString("LastVisit");
                TempData["visit"] = "You visited on " + data;
            }
            OrderRepos rs = new OrderRepos();
            return View(rs.listOrders());
        }


    }
}
