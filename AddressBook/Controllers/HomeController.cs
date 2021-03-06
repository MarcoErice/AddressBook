﻿using System;
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
        private readonly IStringLocalizerFactory factory;
        private readonly IStringLocalizer Localizer;
        private readonly IStringLocalizer<HomeController> homeLocalizer;
        public HomeController(iTimeProvider _timeProvider, 
            IStringLocalizerFactory factory, 
            IStringLocalizer<HomeController> homeLocalizer)
        {
            timeProvider = _timeProvider;
            this.factory = factory;
            this.homeLocalizer = homeLocalizer;
            Localizer = factory.Create(typeof(SharedResource));
        }       
       
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = homeLocalizer["About"];

            return View();
        }

        public IActionResult Contact()
        {
            //var currentThread = System.Threading.Thread.CurrentThread;
            ViewData["Message"] = homeLocalizer["Welcome"];

            return View();
        }

        public IActionResult Cool()
        {
            CoolViewModel m = new CoolViewModel { CoolMessage = "Really nice message!" };
            return View(m);
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
