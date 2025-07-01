using Microsoft.AspNetCore.Mvc;

namespace MobileRechargeWebsite.Controllers
{
    public class AdminController : Controller
    {
  

        public IActionResult Users()
        {
            // Later: Fetch users from database
            return View();
        }

        public IActionResult RechargePlans()
        {
            // Later: Fetch plans from DB
            return View();
        }

        public IActionResult Feedback()
        {
            // Later: Fetch feedback
            return View();
        }
        public IActionResult ManageUsers()
        {
            var userRole = HttpContext.Session.GetString("Role");
            if (userRole != "Admin")
            {
                return RedirectToAction("AccessDenied", "Account"); // or return 403
            }

            // Admin logic here
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Example credentials (replace with database or secure check)
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString("User", "Admin");
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Dashboard");
            }

        
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
