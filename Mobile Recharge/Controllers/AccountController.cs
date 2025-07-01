using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using MobileRechargeWebsite.Models;

namespace HMI.Controllers
{
    public class AccountController : Controller
    {
        private static List<User> users = new List<User>();

        // =========================================================
        // GET: Register (مستخدم عادي)
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register (مستخدم عادي - موبايل 8 خانات)
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (string.IsNullOrEmpty(user.MobileNumber) || user.MobileNumber.Length != 8)
            {
                ViewBag.Error = "Please enter a valid 8-digit mobile number.";
                return View();
            }

            if (users.Any(u => u.MobileNumber == user.MobileNumber))
            {
                ViewBag.Error = "Mobile number already registered.";
                return View();
            }

            users.Add(user);
            TempData["Message"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        // GET: ConfirmTopUp
        public IActionResult ConfirmTopUp()
        {
            List<Plan> plans = GetPlans(); // استرجع بيانات الباقات
            return View(plans); // إرسالها إلى View
        }

        // ✅ دالة مؤقتة لإرجاع بيانات وهمية للباقات
        private List<Plan> GetPlans()
        {
            return new List<Plan>
            {
                new Plan { Id = 1, Name = "Basic Plan", Price = 10 },
                new Plan { Id = 2, Name = "Standard Plan", Price = 20 },
                new Plan { Id = 3, Name = "Premium Plan", Price = 30 }

            };
        }
        
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Login()
        {
            ViewBag.MobileNumber = Request.Cookies["MobileNumber"];
            return View();
        }

        [HttpPost]
        public IActionResult Login(string mobileNumber, string password, bool rememberMe)
        {
            var user = users.FirstOrDefault(u =>
                u.MobileNumber == mobileNumber && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("UserName",
                    string.IsNullOrEmpty(user.FullName) ? user.MobileNumber : user.FullName);

                if (rememberMe)
                {
                    Response.Cookies.Append("MobileNumber", mobileNumber, new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(7)
                    });
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid mobile number or password.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("MobileNumber");
            return RedirectToAction("Index", "Home");
        }
    }
}