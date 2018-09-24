using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shareit.Models;
using shareit.Models.Database;

namespace shareit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShareItContext context;

        public HomeController (ShareItContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Subscribe(string email)
        {
            Subscriber model = new Subscriber()
            {
                Email = email,
                RegisteredDateTime = DateTime.Now
            };

            try 
            {
                context.Subscribers.Add(model);
                context.SaveChanges();
            }
            catch (Exception ex){System.Console.WriteLine(ex.Message); ViewData["title"] = ex.Message;}

            return View("Subscribe");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
