using Microsoft.AspNetCore.Mvc;
using StateManagementServerSide.Models;
using System.Diagnostics;

namespace StateManagementServerSide.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //SetCookie
        public IActionResult SetCookie(string name, int age, string Address)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("UserName", name, options);
            Response.Cookies.Append("Age", age.ToString(), options);
            Response.Cookies.Append("Address", Address, options);
            return RedirectToAction("GetCookie");
        }
        //GetCookie
        public IActionResult GetCookie()
        {
            string name = Request.Cookies["UserName"];
            string age = Request.Cookies["Age"];
            string address = Request.Cookies["Address"];
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Address = address;
            return View();
        }
    }
}
