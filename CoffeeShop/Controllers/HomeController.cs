using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {


        private DBContextModel _context;
        public HomeController (DBContextModel context)
        {
            _context = context;
        }
       

        public IActionResult Index()
        {
            return View(_context.User.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        // This method is posting Registation to the Server
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(user);
                _context.SaveChanges();


                ModelState.Clear();
                ViewBag.Message = "Welcome " + user.FirstName + " " + user.LastName;
            }
            return View();
        }
            public ActionResult Login()
            {
                return View();
            }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var account = _context.User.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            if(account != null)
            {
                HttpContext.Session.SetString("UserID", account.UserID.ToString());
                HttpContext.Session.SetString("UserName", account.UserName.ToString());
                return RedirectToAction("Welcome");

            }
            
            return View();
        }

        public ActionResult Welcome()
        {
            if(HttpContext.Session.GetString("UserID") != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }



        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



    }
}
