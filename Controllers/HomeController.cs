using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            System.Console.WriteLine($"email {email}");
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

        [HttpGet("Home/Data-this-should-not-be-accessed")]
        public IActionResult Data()
        {
            var emails = JsonConvert.SerializeObject(context.Subscribers.ToList());
            return View((object)emails);
        }

        public IActionResult Refresh()
        {
            return Ok("Hello");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
