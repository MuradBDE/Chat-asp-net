using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        MessageContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MessageContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.userName = User.Identity.Name;
            return View(context.Messages.ToList());
        }
        [HttpPost]
        //public async Task<IActionResult> Index(string userName, string message)
        public IActionResult Send(string userName, string message)     //Рабочая версия
        {
            context.Messages.Add(new Message { time = DateTime.Now.ToString(), message = message, user = userName });
            context.SaveChanges();
            return Ok();
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
