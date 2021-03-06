﻿namespace PCBStore.Web.Controllers
{
   using System.Diagnostics;
   using Microsoft.AspNetCore.Mvc;
   using Models;

  
   public class HomeController : Controller
   {
    

      public IActionResult Index()
      {
         return View();
      }

      [Route("[action]")]
      public IActionResult Home()
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
         ViewData["Message"] = "We Would Love to Working with You";

         return View();
      }

      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
