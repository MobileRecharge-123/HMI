using Microsoft.AspNetCore.Mvc;
using MobileRechargeWebsite.Models;

namespace MobileRechargeWebsite.Controllers
{
    public class RechargeController : Controller
    {
        [HttpGet]
        public IActionResult TopUp()
        {
            var plans = new List<RechargePlan>
    {
        new RechargePlan { Amount = 20, Validity = "7 Days", Description = "Basic Plan" },
        new RechargePlan { Amount = 35, Validity = "14 Days", Description = "Standard Plan" },
        new RechargePlan { Amount = 50, Validity = "30 Days", Description = "Premium Plan" }
    };

            return View(plans); // <-- مهم جدًا تمرير plans كموديل للـ View
        }

        [HttpPost]
        public IActionResult TopUp(string mobileNumber, int planId)
        {
            // لو تبغي تعملي معالجة هنا، سويها
            // مثلاً حفظ للبيانات أو غيره

            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }

}