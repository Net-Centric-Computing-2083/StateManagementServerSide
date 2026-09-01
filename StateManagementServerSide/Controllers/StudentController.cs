using Microsoft.AspNetCore.Mvc;

namespace StateManagementServerSide.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(string name)
        {
            //SetSession
            HttpContext.Session.SetString("StudentName", name);

            //TempData
            TempData["Message"] = "Student saved successfully!";
            return RedirectToAction("Details");
        }

        public IActionResult Details()
        {
            //GetSession
            var studentName = HttpContext.Session.GetString("StudentName");

            //GetTempData
            string message = TempData["Message"]?.ToString() 
                ?? "No Message";

            //GetHttpContext
            string context = HttpContext.Request.Method;

            ViewBag.StudentName = studentName;
            ViewBag.Message = message;
            ViewBag.Context = context;
            return View();
        }
    }
}
