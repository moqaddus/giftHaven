using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebWebWeb.Models;

namespace WebWebWeb.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult PrivacyPolicy()
        {
            return View();
        }

        public ViewResult Reviews()
        {
            return View();
        }

        public ViewResult CustomerService()
        {
            return View();
        }

        public ViewResult BestSeller()
        {
            return View();
        }

        public ViewResult Check()
        {
            return View();
        }

        public ViewResult ReturnPolicy()
        {
            return View();
        }


        public ActionResult Home()
        {

            return View("~/Views/Home/Home.cshtml");
        }

        [HttpGet]
        public ActionResult Index(string? user)
        {
            if(user == null)
                return View();
            object u = user;
            return View(u);
        }

        [HttpPost]
        public ActionResult adminLogin(Admin a)/// //// //
        {
            AdminRepost rs = new AdminRepost();
            if (rs.isAdmin(a))
            {
                string name = rs.getName(a);
                TempData["adminName"] ="Welcome "+ name;
                HttpContext.Response.Cookies.Append("adminName", name);

                object s = TempData["adminName"];
                TempData.Remove("adminName");
                return RedirectToAction("Signin", "Admin", new { userName = s });
            }
            object str = "You are not registered as admin!!!";
            return RedirectToAction("Index", "Home", new { user = str });
        }


        [HttpPost]
        public ActionResult userLogin(User u)
        {
            UserRepos userRepos = new UserRepos();
            int id = userRepos.isUser(u);
            if (id!=0)
            {
                var userKiId = id.ToString();
                HttpContext.Response.Cookies.Append("UserID", userKiId);


                // int id=getUserId
                TempData["userid"] = id;
                return RedirectToAction("Home", "Home");
            }
            object str = "You are not registered!!!Please Signup first.";
            return RedirectToAction("Index", "Home", new { user = str });

        }


        [HttpPost]
        public ActionResult userSignUp(User u)
        {
            UserRepos userRepos = new UserRepos();
            userRepos.addUser(u);
            int id = userRepos.isUser(u);
            var userKiId = id.ToString();
            HttpContext.Response.Cookies.Append("UserID", userKiId);

            TempData["userid"] = userRepos.isUser(u);
            return RedirectToAction("Home", "Home");
        }




    }
}