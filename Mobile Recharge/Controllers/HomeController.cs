
using Microsoft.AspNetCore.Mvc;

namespace MobileRechargeWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult About() => View();
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }


        
        public IActionResult CustomerCare() => View();
        public IActionResult SiteMap() => View();
        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Feedback(string name, string email, string message)
        {
            ViewBag.Status = "Your feedback has been successfully submitted. Thank you for contacting us!";
            return View();
        }
    }
    }
