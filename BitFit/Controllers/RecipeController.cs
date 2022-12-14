﻿using BitFit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitFit.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RecipeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Recipes()
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