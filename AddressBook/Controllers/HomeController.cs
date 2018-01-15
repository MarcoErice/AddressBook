using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using AddressBook.Interfaces;
using Microsoft.Extensions.Localization;
using AddressBook.Resources;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        private iTimeProvider timeProvider;
        private readonly IStringLocalizer _Localizer;
        public HomeController(iTimeProvider _timeProvider, IStringLocalizerFactory factory)
        {
            timeProvider = _timeProvider;
            _Localizer = factory.Create(typeof(SharedResource));
        }       
       
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            var currentThread = System.Threading.Thread.CurrentThread;
            ViewData["Message"] = _Localizer["Welcome"];

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddOneMonth()
        {
            timeProvider.Now = timeProvider.Now.AddMonths(1);
            ViewBag.Time = timeProvider.Now.ToString();
            return View("Index");
        }
        public IActionResult SubtractOneMonth()
        {
            timeProvider.Now = timeProvider.Now.AddMonths(-1);
            ViewBag.Time = timeProvider.Now.ToString();
            return View("Index");
        }
    }
}
