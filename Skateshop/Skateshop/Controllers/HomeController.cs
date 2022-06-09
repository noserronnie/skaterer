﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skaterer.Services;
using Skateshop.Data;
using Skateshop.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Skateshop.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var bestProducts = await _productService.GetProductsByRating(10);
            return View(bestProducts);
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
